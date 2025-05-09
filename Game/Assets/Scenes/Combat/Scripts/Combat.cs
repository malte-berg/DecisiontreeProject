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

    public void Init(){

        // Create markers
        marker = Instantiate(marker);
        markerT = marker.transform;
        targeting = Instantiate(targeting);

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
        player.healthBar.UpdateBar(player.HP, player.Vitality);

        // Update ManaBar on the player
        player.Mana = player.MaxMana;
        player.manaBar.UpdateBar(player.Mana, player.MaxMana);
      
        // Reset cooldown
        for(int i = 0; i < player.SkillCount; i++)
            player.skills[i].cooldownCount = 0;

        // Spawn enemies
        int spawnIndex = (player.CurrentAreaIndex-1) * 2;
        System.Random rand = new System.Random((int)player.Seed + player.CurrentAreaIndex * 420 + player.CombatsWon * 1337);
        if(player.CombatsWon == 10){

            for (int i = 0; i < 2; i++) {
                SpawnEnemy(enemyPrefabs[spawnIndex + rand.Next() % 2], rand);
            }
            // spawn a boss!
            SpawnEnemy(enemyPrefabs[spawnIndex + 6], rand);

        } else {

            for (int i = 0; i < 4; i++)
                SpawnEnemy(enemyPrefabs[spawnIndex + rand.Next() % 2], rand);
        }

        GetCurrentCharacter();

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
        cEnemy.CreateEnemy(AreaDataLoader.GetAreaItems(player.CurrentAreaIndex), rand.NextDouble(), prefab.name);
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
        cEnemy.healthBar.UpdateBar(cEnemy.HP, cEnemy.Vitality);

        // Update ManaBar on the cEnemy
        cEnemy.Mana = cEnemy.MaxMana;
        cEnemy.manaBar.UpdateBar(cEnemy.Mana, cEnemy.MaxMana);

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
                    player.AddExp(25);          // Give EXP for winning the battle
                    player.Gold += 15;          // Give Gold for winning the battle
                    int difficulty = (int)MathF.Log(player.CombatsWon, MathF.E) + 1;
                    player.AddExp(difficulty * player.CurrentAreaIndex * player.CurrentAreaIndex * 5);      // Give EXP for winning the battle
                    player.Gold += difficulty * player.CurrentAreaIndex * 15;                               // Give Gold for winning the battle
                    player.MaxMana = 10 * player.CurrentLevel;
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
        player.AddExp((player.CurrentAreaIndex + 1) * (player.CurrentAreaIndex + 1));
        SceneManager.LoadScene("DemoLoseScreen");
        Debug.LogWarning("Main character died lol");

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
            print("it failed :(");
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

        targeting.GetComponent<Targeting>().HoverOn(hover.transform);

    }

}
