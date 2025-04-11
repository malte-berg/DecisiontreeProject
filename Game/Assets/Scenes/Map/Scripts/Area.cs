using UnityEngine;

public abstract class Area {
    
    // hold current area in player?
    public abstract void Init();
    public abstract Item[] GetItems();

}