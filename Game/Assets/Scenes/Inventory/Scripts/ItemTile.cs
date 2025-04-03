using TMPro;
using UnityEngine;

public class ItemTile : MonoBehaviour{

    Item item;
    Player player;
    InventoryManager im;

    public void Init(InventoryManager im, Item item){

        this.im = im;
        this.player = im.player;
        this.item = item;
        UpdateVisuals();

    }

    public void UpdateVisuals(){

        gameObject.GetComponentInChildren<TMP_Text>().text = item.Name;

    }

    public void Pressed(){

        im.id.DisplayItem(item);
        im.sl.UpdateStats();

    }

}
