using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Combat : MonoBehaviour{

    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public GameObject healthBarPrefab;
    public GameObject marker;
    public GameObject targeting;
    Player player;
    List<Enemy> enemies = new List<Enemy>();

    int turn = 0;
    GameCharacter currentC;

    public void Init(){

        marker = Instantiate(marker);
        targeting = Instantiate(targeting);

        player = GameObject.Find("Player").GetComponent<Player>(); //horrible way of doing this
        player.ShowPlayer();
        player.c = this;
        player.transform.position = new Vector3(-4, 0, 0);
        GetCurrentCharacter();

        //Add a healthbar for the player and put it inside the canvas.
        Vector3 healthBarPosition = Camera.main.WorldToScreenPoint(player.gameObject.transform.position + Vector3.up*2);
        player.healthBar = Instantiate(healthBarPrefab, healthBarPosition, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<HealthBar>();
        player.healthBar.Init();
        player.healthBar.gameObject.name = "PlayerHP";
        player.healthBar.UpdateHealthBar(player.HP, player.Vitality);

        for(int i = 0; i < 4; i++){ // TEMP SPAWN ENEMIES

            CreateEnemy();

        }

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

        // move marker aswell
        marker.transform.position = current.gameObject.transform.position;
        print("jaughu");
        return current;

    }

    public Enemy CreateEnemy(){

        int i = enemies.Count;

        enemies.Add(Instantiate(enemyPrefab).GetComponent<Enemy>());
        enemies[i].Init();
        enemies[i].c = this;
        enemies[i].gameObject.name = "Enemy #" + i;

        if(i % 2 == 0)
            enemies[i].transform.position = Vector3.right * (i+1) * 2 + (Vector3.up * i * 0.5f);
        else
            enemies[i].transform.position = Vector3.right * (i+1) * 2 - (Vector3.up * (i+1) * 0.25f);

        //Add a healthbar for the enemy and put it inside the canvas.
        Vector3 enemyHealthBarPosition = Camera.main.WorldToScreenPoint(enemies[i].gameObject.transform.position + Vector3.up*2);   //Place healthbar above character.
        enemies[i].healthBar = Instantiate(healthBarPrefab, enemyHealthBarPosition, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<HealthBar>();
        enemies[i].healthBar.Init();
        enemies[i].healthBar.gameObject.name = enemies[i].gameObject.name + " HP";
        enemies[i].healthBar.UpdateHealthBar(enemies[i].HP, enemies[i].Vitality);
        return enemies[i];

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
        Debug.LogError("Main character died lol");

    }

    public void CharacterClicked(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        print($"{currentC.gameObject.name}: clicked {clicked.gameObject.name}");

        if(!currentC.UseSkill(clicked)){
            print("it failed :(");
            return;
        }

        if(currentC != null)
            print("yay");
        else
            print("nay");

        turn = (turn + 1) % (enemies.Count + 1);
        currentC = GetCurrentCharacter();

        if(currentC is Enemy)
            new Task(async () => { await (currentC as Enemy).AI(this, player);}).Start();
            // (currentC as Enemy).AI(this, player);

    }

    public void CharacterHover(GameCharacter hover){

        targeting.GetComponent<Targeting>().HoverOn(hover.transform);

    }

}
