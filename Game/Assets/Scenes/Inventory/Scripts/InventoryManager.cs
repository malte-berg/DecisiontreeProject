using UnityEngine;

public class InventoryManager : MonoBehaviour{

    public ItemTile[] iTs = new ItemTile[0];
    public Player player;

    public void Init(){

        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();
        GetComponentInChildren<InventoryList>().Init(this);
        GetComponentInChildren<StatsList>().Init(this);

    }

    void Awake(){

        Init();

    }

}
