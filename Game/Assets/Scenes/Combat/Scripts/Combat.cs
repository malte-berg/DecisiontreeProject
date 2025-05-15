using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour{

    public GameObject[] enemyPrefabs;
    public GameObject playerPrefab;
    public GameObject barPrefab;
    public GameObject marker;
    Transform markerT;
    public GameObject targeting;
    Player player;
    List<Enemy> enemies = new List<Enemy>();

    public List<Enemy> Enemies{ get { return enemies; }}

    public SkillBook sb = new SkillBook();

    int turn = 0;
    GameCharacter currentC;

    private AudioSource playerDead;
    private AudioSource enemyDead;

    public void Init(){

        // Create markers
        marker = Instantiate(marker);
        markerT = marker.transform;
        targeting = Instantiate(targeting);
        targeting.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // Fix player positioning
        player.c = this;
        player.ShowPlayer();
        player.transform.position = new Vector3(-4, 0, 0);
        
        // Create status bar
        player.bars = CreateBars(player);
        player.Moved();

        // Update HealthBar on the player
        player.HP = player.Vitality;
        player.healthBar.UpdateBar(player.HP, player.Vitality, 0);

        // Update ManaBar on the player
        player.Mana = player.MaxMana;
        player.manaBar.UpdateBar(player.Mana, player.MaxMana, 1);

        SpriteRenderer[] sr = new SpriteRenderer[7];
        Transform container = player.transform.GetChild(0);

        for(int i = 0; i < sr.Length; i++) {
            sr[i] = container.GetChild(i).GetComponent<SpriteRenderer>();
        }

        foreach (SpriteRenderer s in sr) {
            s.color = Color.white;
            // s.color = new Color(s.color.r, s.color.g, s.color.b, 1);
        }

        // Reset cooldown
        for(int i = 0; i < player.SkillCount; i++)
            player.skills[i].cooldownCount = 0;
        System.Random tutRand = new System.Random(12);

        // Set up tutorial-specific setup if in tutorial area
        if (player.CurrentAreaIndex == 0 && player.CombatsWon == 0) {
            
            SetupTutorialPlayer();
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).gameObject.SetActive(false);   //Make return button in tutorial disappear.
            for (int i = 0; i < 4; i++) {
                int rnd = UnityEngine.Random.Range(0, 1);
                SpawnEnemy(enemyPrefabs[rnd], tutRand);
            }

        } else {
            // Spawn enemies
            int spawnIndex = player.CurrentAreaIndex-1;
            System.Random rand = new System.Random((int)player.Seed + player.CurrentAreaIndex * 420 + player.CombatsWon * 1337);
            if(player.CombatsWon == 10){

                for (int i = 0; i < 2; i++) {
                    SpawnEnemy(enemyPrefabs[spawnIndex*2 + rand.Next() % 2], rand);
                }
                // spawn a boss!
                SpawnEnemy(enemyPrefabs[spawnIndex + 6], rand);

            } else {

                for (int i = 0; i < 3 && i < player.CurrentAreaIndex + player.CombatsWon; i++)
                    SpawnEnemy(enemyPrefabs[spawnIndex*2 + rand.Next() % 2], rand);
            }
          
        }

        AudioInit();
        GetCurrentCharacter();

    }

    private void AudioInit(){
        AudioSource[] sources = GetComponents<AudioSource>();

        playerDead = sources[0];
        enemyDead = sources[1];
    }

    public void PlayDeathSound(GameCharacter character){
        if (character.IsPlayer()){
            playerDead.Play();
        } else{
            enemyDead.Play();
        }
    }
    RectTransform CreateBars(GameCharacter who){

        GameObject t = Instantiate(barPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);

        // Setup healthBar
        Bar hb = t.transform.GetChild(0).GetChild(0).GetComponent<Bar>();
        hb.Init();
        who.healthBar = hb;

        // Setup manaBar
        Bar mb = t.transform.GetChild(0).GetChild(1).GetComponent<Bar>();
        mb.Init();
        who.manaBar = mb;

        // Setup text
        string levelText = who is Player player ? player.CurrentLevel.ToString() : (who as Enemy)?.level.ToString();
        t.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>().text = $"{who.CName} LV.{levelText}";

        return t.GetComponent<RectTransform>();

    }

    void Awake(){

        Init();

    }

    GameCharacter GetCurrentCharacter(){

        GameCharacter current;

        if(turn == 0)
            current = player;
        else
            current = enemies[turn - 1];

        markerT.position = current.transform.position;
        return current;

    }

    public Enemy SpawnEnemy(GameObject prefab, System.Random rand){

        int i = enemies.Count;

        // Create enemy
        Enemy cEnemy = Instantiate(prefab).GetComponent<Enemy>();
        cEnemy.Init();
        cEnemy.CreateEnemy(AreaDataLoader.GetAreaItems(player.CurrentAreaIndex), rand.NextDouble(), player.CombatsWon, prefab.name);
        cEnemy.gameObject.name = $"{prefab.name} (E{i})";
        cEnemy.c = this;

        if(prefab.name.Contains("Boss")) {
            cEnemy.transform.position = Vector3.right * 6.5f;
            cEnemy.transform.position = Vector3.up * 1f;
            cEnemy.transform.localScale *= 1.3f;
            cEnemy.transform.GetChild(0).position += new Vector3(0f,0.24f,0f);
        }

        // Place enemy
        else if(i % 2 == 0)
            cEnemy.transform.position = Vector3.right * (i+1) * 2 + (Vector3.up * i * 0.5f);
        else
            cEnemy.transform.position = Vector3.right * (i+1) * 2 - (Vector3.up * (i+1) * 0.25f);

        // Create status bar
        cEnemy.bars = CreateBars(cEnemy);
        cEnemy.Moved();

        // Update HealthBar on the cEnemy
        cEnemy.HP = cEnemy.Vitality;
        cEnemy.healthBar.UpdateBar(cEnemy.HP, cEnemy.Vitality, 0);

        // Update ManaBar on the cEnemy
        cEnemy.Mana = cEnemy.MaxMana;
        cEnemy.manaBar.UpdateBar(cEnemy.Mana, cEnemy.MaxMana, 1);

        enemies.Add(cEnemy);
        return cEnemy;

    }

    public async Task KillCharacter(GameCharacter target){

        SpriteRenderer[] sr = new SpriteRenderer[7];
        Transform container = target.transform.GetChild(0);
        for(int i = 0; i < sr.Length; i++) {
            sr[i] = container.GetChild(i).GetComponent<SpriteRenderer>();
        }
        float time = 1;

        if(target is Enemy){

            int enemyCount = enemies.Count;
            if(enemies.Remove(target as Enemy)){

                while(time > 0){

                    foreach (SpriteRenderer s in sr) {
                        s.color = new Color(time,time,time,time);                        
                    }
                    time -= Time.deltaTime;
                    await Task.Yield();

                }


                Destroy(target.bars.gameObject);
                Destroy(target.gameObject);

                //All enemies are dead: Change to the "Win Screen".
                if (enemyCount == 1){
                    player.CombatsWon++;
                    int difficulty = (int)MathF.Log(player.CombatsWon, MathF.E) + 1;
                    int expEarned = difficulty * player.CurrentAreaIndex * player.CurrentAreaIndex * 5;
                    int goldEarned = difficulty * player.CurrentAreaIndex * 15;
                    player.AddExp(expEarned); // Give EXP for winning the battle
                    player.Gold += goldEarned; // Give Gold for winning the battle
                    RewardData.expEarned = expEarned;
                    RewardData.goldEarned = goldEarned;
                    player.HidePlayer();
                    SceneManager.LoadScene("DemoWinScreen");
                }

                return;
            }

        } else if (target != player)
            Debug.LogError("Something unknown died..");

        while(time > 0){

            foreach (SpriteRenderer s in sr) {
                s.color = new Color(time,time,time,time);
            }           
            time -= Time.deltaTime;
            await Task.Yield();

        }

        // GAME OVER (Player died)

        if (player.CurrentAreaIndex == 0) {
            player.RemoveSkillAt(2);
            player.RemoveSkillAt(1);

            // Reset mana after tutorial
            player.Mana = 1;
            player.MaxMana = 1;

            // Reset Magic after the tutorial
            player.UpdateStats(0, 0, -5);

            player.CurrentAreaIndex = 1;

            //Switch Scene to the in game menu scene, with the Intro cutscene.
            GetComponent<SceneSwitch>().WithCutscene = 0;
            GetComponent<SceneSwitch>().SwitchScene(1);
        } else {
            int gainedExp = (player.CurrentAreaIndex + 1) * (player.CurrentAreaIndex + 1);
            player.AddExp(gainedExp);
            RewardData.expEarned = gainedExp;
            RewardData.goldEarned = 0;
            SceneManager.LoadScene("DemoLoseScreen");
        }
    }

    public void CharacterClicked(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        if(currentC == player)
            UseTurnOn(clicked);

    }

    public bool UseTurnOn(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        if(!currentC.UseSkill(clicked)){
            return false;
        }

        NewTurn();
        return true;

    }

    void NewTurn(){

        currentC = GetCurrentCharacter();
        List<StatusEffect> se = currentC.statusEffects;

        // Decrement and remove status effects
        for(int i = 0; i < se.Count; i++){

            if(se[i].Turns == 0){

                se.RemoveAt(i);
                i--;
                continue;

            }

            se[i].DecrementEffect();

        }

        // Decrement cooldown
        for(int i = 0; i < currentC.skills.Length; i++){

            if(currentC.skills[i] == null)
                break;
            
            currentC.skills[i].cooldownCount--;

        }

        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).GetChild(0).GetComponent<SkillSelection>().UpdateSkillButtons();

        // Calculate next turn index
        turn = (turn + 1) % (enemies.Count + 1);

        currentC = GetCurrentCharacter();
        se = currentC.statusEffects;

        for(int i = 0; i < se.Count; i++){

            if(se[i].EffectType == 5){ // Stunned skipping turn

                NewTurn();
                return;
                
            }

        }

        if(currentC is Enemy)
            new Task(async () => { (currentC as Enemy).AI(this, player);}).Start();

    }

    public void CharacterHover(GameCharacter hover){

        targeting.SetActive(true);

        targeting.GetComponent<Targeting>().HoverOn(hover.transform);

    }

    private void SetupTutorialPlayer()
    {
        player.Mana = 20;
        player.MaxMana = 20;

        // Add 5 Magic
        player.UpdateStats(0, 0, 5);

        Skill heal = new Heal();
        heal.UnlockSkill(player);
        player.AddSkill(heal);

        Skill sacrifice = new Sacrifice();
        sacrifice.UnlockSkill(player);
        player.AddSkill(sacrifice);

        player.CombatsWon = 1;
    }
}
