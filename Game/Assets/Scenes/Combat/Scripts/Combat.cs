using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour{

    public GameObject characterPrefab;
    GameCharacter player;
    List<GameCharacter> enemies = new List<GameCharacter>();

    int turn = 0;
    GameCharacter currentC;

    void Start(){

        player = Instantiate(characterPrefab).GetComponent<GameCharacter>();
        player.Init(this);
        player.gameObject.name = "Player";

        for(int i = 0; i < 3; i++){

            enemies.Add(Instantiate(characterPrefab).GetComponent<GameCharacter>());
            enemies[i].Init(this);
            enemies[i].gameObject.name = "Enemy #" + i;

        }

    }

    GameCharacter GetCurrentCharacter(){

        if(turn == 0)
            return player;
        
        return enemies[turn - 1];

    }

    public void KillCharacter(GameCharacter target){

        if(enemies.Remove(target)){

            Destroy(target.gameObject);
            return;
        
        }

        // GAME OVER (Player died)
        UnityEngine.Debug.LogError("Main character died, sadge");

    }

    public void CharacterClicked(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        print(currentC.gameObject.name + " is using a skill on " + clicked.gameObject.name);

        if(!currentC.UseSkill(clicked)){
            print("it failed :(");
            return;
        }

        turn = (turn + 1) % (enemies.Count + 1);
        currentC = GetCurrentCharacter();

    }

}
