using UnityEngine;

public class Consumable : Item {

    string name;
    int value;

    public Consumable(string name, int value) : base(name, value){

        this.name = name;
        this.value = value;

    }

    /* public void Consume(){ 

        could be more inheritance with separate override functions for each consumable
        or
        int type switch in the function

    } */

}
