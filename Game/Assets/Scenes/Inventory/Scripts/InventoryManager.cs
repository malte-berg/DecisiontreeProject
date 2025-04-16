using UnityEngine;

public class InventoryManager : MonoBehaviour{

    public ItemTile[] iTs = new ItemTile[0];
    public Player player;
    public InventoryList il;
    public StatsList sl;
    public ItemDescription id;

    public void Init(){

        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice

        // Show and position player above stats
        player.ShowPlayer();
        player.transform.position = new Vector3(-5.3f, 1.8f, -1);
        player.SM.SetCharacter(player);

        il = GetComponentInChildren<InventoryList>();
        il.Init(this);
        sl = GetComponentInChildren<StatsList>();
        sl.Init(this);
        id = GetComponentInChildren<ItemDescription>();
        id.Init(this);

    }

    void Awake(){

        Init();

    }

}
