using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour{

    // List<GameCharacter> player = new List<GameCharacter>();
    public GameObject prefab;
    GameCharacter player;
    List<GameCharacter> enemies = new List<GameCharacter>();

    int turn = 0;
    GameCharacter currentC;

    void Start(){

        player = Instantiate(prefab).GetComponent<GameCharacter>();
        player.Init(this);

        for(int i = 0; i < 3; i++){
            enemies.Add(Instantiate(prefab).GetComponent<GameCharacter>());
            enemies[i].Init(this);
        }

    }

    GameCharacter GetCurrentCharacter(){

        if(turn == 0)
            return player;
        
        return enemies[turn - 1];

    }

    public void CharacterClicked(GameCharacter clicked){

        if(currentC == null)
            currentC = GetCurrentCharacter();

        if(currentC != clicked) currentC.Attack(clicked);

        turn = (turn + 1) % (enemies.Count + 1);
        currentC = GetCurrentCharacter();

    }

}
