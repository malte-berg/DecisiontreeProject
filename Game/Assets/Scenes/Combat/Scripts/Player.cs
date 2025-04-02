using UnityEngine;

public class Player : GameCharacter {

    // PLAYER STATS
    int gold;
    int skillPoints;

    // public Player() : base(){

    // }

    public override void Init(Combat c){

        this.c = c;
        equipment = gameObject.GetComponent<Equipment>();
        DontDestroyOnLoad(gameObject);

    //     int gold = 10;
    //     int skillPoints = 0;

    }
    
}
