using UnityEngine;

public abstract class Item{

    string name;
    int value;

    public string Name{ get{ return name; } }
    public int Value{ get{ return value; } }

    public Item(string name, int value){

        this.name = name;
        this.value = value;

    }
}
