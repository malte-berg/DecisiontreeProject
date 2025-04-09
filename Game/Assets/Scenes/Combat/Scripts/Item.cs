using UnityEngine;

public abstract class Item{

    string name;
    int value;
    string description;

    public string Name{ get{ return name; } }
    public int Value{ get{ return value; } }
    public string Description{ get { return description; } }

    public Item(string name, int value, string description){

        this.name = name;
        this.value = value;
        this.description = description;

    }
}
