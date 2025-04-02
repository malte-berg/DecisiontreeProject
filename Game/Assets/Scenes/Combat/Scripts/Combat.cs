using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Combat : MonoBehaviour{

    public GameObject characterPrefab;
    public GameObject playerPrefab;
    public GameObject marker;
    Player player;
    List<GameCharacter> enemies = new List<GameCharacter>();

    int turn = 0;
    GameCharacter currentC;

    public void Init(){

        marker = Instantiate(marker);

    }

    void Awake(){

        Init();

    }

    void Start(){ // TEMP

        player = Instantiate(playerPrefab).GetComponent<Player>();
        player.gameObject.name = "Player";
        player.Init(this);

        for(int i = 0; i < 3; i++){

            enemies.Add(Instantiate(characterPrefab).GetComponent<GameCharacter>());
            enemies[i].Init(this);
            enemies[i].gameObject.name = "Enemy #" + i;
            enemies[i].transform.position = Vector3.right * (i+1) * 2;

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
