using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour{

    public GameObject characterPrefab;
    public GameObject marker;
    GameCharacter player;
    List<GameCharacter> enemies = new List<GameCharacter>();

    int turn = 0;
    GameCharacter currentC;

    public void Init(){

        marker = Instantiate(marker);

    }

    void Awake(){

        Init();

    }

    void Start(){

        player = Instantiate(characterPrefab).GetComponent<GameCharacter>();
        player.Init(this);
        player.gameObject.name = "Player";

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

    public void KillCharacter(GameCharacter target){

        if(enemies.Remove(target)){

            Destroy(target.gameObject);
            return;
        
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
