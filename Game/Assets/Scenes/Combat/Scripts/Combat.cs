using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour{

    public GameObject characterPrefab;
    public GameObject marker;
    public GameObject healthBarPrefab;
    GameCharacter player;
    List<GameCharacter> enemies = new List<GameCharacter>();
    List<HealthBar> enemyHealthBars = new List<HealthBar>();

    int turn = 0;
    GameCharacter currentC;

    public void Init(){

        marker = Instantiate(marker);

    }

    void Awake(){

        Init();

    }

    void Start(){

        //Instantiate the "player" character
        player = Instantiate(characterPrefab).GetComponent<GameCharacter>();
        player.gameObject.name = "Player";
        player.Init(this);

        //Add a healthbar for the player and put it inside the canvas.
        Vector3 healthBarPosition = Camera.main.WorldToScreenPoint(player.gameObject.transform.position + Vector3.up*2);
        GameObject healthBar = Instantiate(healthBarPrefab, healthBarPosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        healthBar.GetComponent<HealthBar>().player = player.gameObject; //Connect the healthbar to the player character.
        healthBar.name = "PlayerHP";

        for(int i = 0; i < 3; i++){

            enemies.Add(Instantiate(characterPrefab).GetComponent<GameCharacter>());
            enemies[i].Init(this);
            enemies[i].gameObject.name = "Enemy #" + i;
            enemies[i].transform.position = Vector3.right * (i+1) * 2;

            //Add a healthbar for the enemy and put it inside the canvas.
            Vector3 enemyHealthBarPosition = Camera.main.WorldToScreenPoint(enemies[i].gameObject.transform.position + Vector3.up*2);   //Place healthbar above character.
            enemyHealthBars.Add(Instantiate(healthBarPrefab, enemyHealthBarPosition, Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<HealthBar>()); //Instantiate the healthbar inside the "Canvas" object.
            enemyHealthBars[i].player = enemies[i].gameObject; //Connect the healthbar to the enemy character.
            enemyHealthBars[i].gameObject.name = enemies[i].gameObject.name + " HP";
            //enemyHealthBars[i].gameObject.transform.Find("Fill").GetComponent<Image>().color = Color.red; //Change color of enemy health bars to red.
        }

    }

    GameCharacter GetCurrentCharacter(){

        GameCharacter current = null;

        if(turn == 0)
            current = player;
        else
            current = enemies[turn - 1];

        // move marker aswell
        marker.transform.position = current.gameObject.transform.position;
        return current;

    }

    public async Task KillCharacter(GameCharacter target){

        SpriteRenderer sr = target.gameObject.GetComponentInChildren<SpriteRenderer>();
        float time = 1;

        if(enemies.Remove(target)){

            while(time > 0){

                sr.color = new Color(time,time,time,time);
                time -= Time.deltaTime;
                await Task.Yield();

            }

            Destroy(target.gameObject);
            return;
        
        }

        while(time > 0){

            sr.color = new Color(time,time,time,time);
            time -= Time.deltaTime;
            await Task.Yield();

        }

        // GAME OVER (Player died)
        UnityEngine.Debug.LogError("Main character died lol");

    }

    public void CharacterClicked(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        if(!currentC.UseSkill(clicked)){
            print("it failed :(");
            return;
        }

        turn = (turn + 1) % (enemies.Count + 1);
        currentC = GetCurrentCharacter();

    }

}
