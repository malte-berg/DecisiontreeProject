using UnityEngine;

public class InventoryList : MonoBehaviour {

    public GameObject itemTilePrefab;
    InventoryManager im;
    Player player;
    Transform content;

    public void Init(InventoryManager im){

        // Inventory/Panel/Scroll View/View Port/Content
        this.im = im;
        player = im.player;
        content = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0);
        UpdateTiles();
        
    }

    public void UpdateTiles(){

        if(player == null)
            return;

        if(player.inventory == null)
            return;

        for(int i = 0; i < im.iTs.Length; i++)
            Destroy(im.iTs[i]);

        im.iTs = new ItemTile[player.inventory.Length];

        for(int i = 0; i < player.inventory.Length; i++){

            if(player.inventory[i] == null)
                continue;

            im.iTs[i] = Instantiate(itemTilePrefab, content).GetComponent<ItemTile>();
            im.iTs[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-25 - 50*i);
            im.iTs[i].Init(player.inventory[i]);

        }

    }
    
}
