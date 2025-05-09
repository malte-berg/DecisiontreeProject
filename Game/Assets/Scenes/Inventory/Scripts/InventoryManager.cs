using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour{

    public ItemTile[] iTs = new ItemTile[0];
    public Player player;
    public InventoryList il;
    public StatsList sl;
    public ItemDescription id;
    public Image bg;

    public void Init(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); // bad practice

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

    void setBackgrund(){
        AreaData ad = AreaDataLoader.Load(player.CurrentAreaIndex);
        bg.sprite = ad.backgroundImage;
    }

    void Awake(){

        Init();
        setBackgrund();

    }

}
