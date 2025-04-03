using UnityEngine;

public class InventoryManager : MonoBehaviour{

    public ItemTile[] iTs = new ItemTile[0];
    public Player player;
    public InventoryList il;
    public StatsList sl;

    public void Init(){

        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();
        il = GetComponentInChildren<InventoryList>();
        il.Init(this);
        sl = GetComponentInChildren<StatsList>();
        sl.Init(this);

    }

    void Awake(){

        Init();

    }

}
