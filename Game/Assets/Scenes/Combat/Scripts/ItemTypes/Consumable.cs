using UnityEngine;

public class Consumable : Item {

    public Consumable(string name, int value, string description) : base(name, value, description){

    }

    /* public void Consume(){ 

        could be more inheritance with separate override functions for each consumable
        or
        int type switch in the function

    } */
}
