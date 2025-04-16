using System.Collections.Generic;
using UnityEngine;

public abstract class Item{

    string name;
    int value;
    string description;

    public string Name{ get{ return name; } }
    public int Value{ get{ return value; } }
    public string Description{ get { return description; } }
    public List<Sprite> sprites;
    public Sprite sprite;
    public Sprite icon;

    public Item(string name, int value, string description){

        this.name = name;
        this.value = value;
        this.description = description;

    }
}
