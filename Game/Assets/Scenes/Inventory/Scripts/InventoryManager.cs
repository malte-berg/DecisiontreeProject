using UnityEngine;
using UnityEditor;

public class InventoryManager : MonoBehaviour{

    ItemTile[] iTs = new ItemTile[0];
    public GameObject itemTilePrefab;
    public GameCharacter player;
    Transform content;

    public void Init(){

        // Inventory/Panel/Scroll View/View Port/Content
        content = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0);
        
    }

    void Awake() {

        Init();

    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Space))
            UpdateTiles();

    }

    public void UpdateTiles(){

        if(player == null)
            return;

        if(player.inventory == null)
            return;

        for(int i = 0; i < iTs.Length; i++)
            Destroy(iTs[i]);

        iTs = new ItemTile[player.inventory.Length];

        for(int i = 0; i < player.inventory.Length; i++){

            if(player.inventory[i] == null)
                continue;

            iTs[i] = Instantiate(itemTilePrefab, content).GetComponent<ItemTile>();
            iTs[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-25 - 50*i);
            iTs[i].Init(player.inventory[i]);

        }

    }

}
