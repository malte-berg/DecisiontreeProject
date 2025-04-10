using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour{

    public GameObject[] enemyPrefabs;
    public GameObject playerPrefab;
    public GameObject healthBarPrefab;
    public GameObject manaBarPrefab;
    public GameObject marker;
    Transform markerT;
    public GameObject targeting;
    Player player;
    List<Enemy> enemies = new List<Enemy>();

    public List<Enemy> Enemies{ get { return enemies; }}

    int turn = 0;
    GameCharacter currentC;

    public void Init(){

        marker = Instantiate(marker);
        markerT = marker.transform;
        targeting = Instantiate(targeting);

        player = GameObject.Find("Player").GetComponent<Player>(); //horrible way of doing this
        player.ShowPlayer();
        player.c = this;
        player.transform.position = new Vector3(-4, 0, 0);

        //Add a healthbar for the player and put it inside the canvas.
        player.healthBar = Instantiate(healthBarPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<HealthBar>();
        player.healthBar.Init();
        player.healthBar.gameObject.name = "PlayerHP";
        player.HP = player.Vitality;
        player.healthBar.UpdateHealthBar(player.HP, player.Vitality);

        BarsPosition followHP = player.healthBar.gameObject.AddComponent<BarsPosition>();
        followHP.target = player.transform;
        followHP.offset = Vector3.up * 2f;

        //Add a mana bar for the player and put it inside the canvas.
        player.manaBar = Instantiate(manaBarPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<ManaBar>();
        player.manaBar.gameObject.name = "PlayerMBar";
        player.manaBar.targetCharacter = player;

        BarsPosition followMP = player.manaBar.gameObject.AddComponent<BarsPosition>();
        followMP.target = player.transform;
        followMP.offset = Vector3.up * 2.215f;

        for (int i = 0; i < 4; i++) // TEMP SPAWN ENEMIES
            SpawnEnemy(enemyPrefabs[0]);

        GetCurrentCharacter();

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

    public Enemy SpawnEnemy(GameObject prefab){

        int i = enemies.Count;

        Enemy cEnemy = Instantiate(prefab).GetComponent<Enemy>();
        enemies.Add(cEnemy);
        cEnemy.gameObject.name = $"{prefab.name} #{i}";
        cEnemy.Init();
        cEnemy.c = this;

        if(i % 2 == 0)
            cEnemy.transform.position = Vector3.right * (i+1) * 2 + (Vector3.up * i * 0.5f);
        else
            cEnemy.transform.position = Vector3.right * (i+1) * 2 - (Vector3.up * (i+1) * 0.25f);

        //Add a healthbar for the enemy and put it inside the canvas.
        cEnemy.healthBar = Instantiate(healthBarPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<HealthBar>();
        cEnemy.healthBar.Init();
        cEnemy.healthBar.gameObject.name = cEnemy.gameObject.name + " HP";
        cEnemy.healthBar.UpdateHealthBar(cEnemy.HP, cEnemy.Vitality);

        BarsPosition followHP = cEnemy.healthBar.gameObject.AddComponent<BarsPosition>();
        followHP.target = cEnemy.transform;
        followHP.offset = Vector3.up * 2f;

        //Add a mana bar for the enemy and put it inside the canvas.
        cEnemy.manaBar = Instantiate(manaBarPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<ManaBar>();
        cEnemy.manaBar.targetCharacter = enemies[i];
        cEnemy.manaBar.gameObject.name = enemies[i].gameObject.name + " MBar";

        BarsPosition followMP = cEnemy.manaBar.gameObject.AddComponent<BarsPosition>();
        followMP.target = cEnemy.transform;
        followMP.offset = Vector3.up * 2.215f;
        return cEnemy;

    }

    public async Task KillCharacter(GameCharacter target){

        SpriteRenderer sr = target.gameObject.GetComponentInChildren<SpriteRenderer>();
        float time = 1;

        if(target is Enemy){

            if(enemies.Remove(target as Enemy)){

                while(time > 0){

                    sr.color = new Color(time,time,time,time);
                    time -= Time.deltaTime;
                    await Task.Yield();

                }

                Destroy(target.healthBar.gameObject);
                Destroy(target.gameObject);

                //All enemies are dead: Change to the "Win Screen".
                if (enemies.Count == 0){
                    SceneManager.LoadScene("DemoWinScreen");
                    player.HidePlayer();
                }

                return;
            }

        } else if (target != player)
            Debug.LogError("Something unknown died..");

        while(time > 0){

            sr.color = new Color(time,time,time,time);
            time -= Time.deltaTime;
            await Task.Yield();

        }

        // GAME OVER (Player died)
        SceneManager.LoadScene("DemoLoseScreen");
        Debug.LogError("Main character died lol");

    }

    public void CharacterClicked(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        if(currentC == player)
            UseTurnOn(clicked);

    }

    public void UseTurnOn(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        if(!currentC.UseSkill(clicked)){
            print("it failed :(");
            return;
        }

        turn = (turn + 1) % (enemies.Count + 1);
        currentC = GetCurrentCharacter();

        if(currentC is Enemy)
            new Task(async () => { (currentC as Enemy).AI(this, player);}).Start();

    }

    public void CharacterHover(GameCharacter hover){

        targeting.GetComponent<Targeting>().HoverOn(hover.transform);

    }

}
