using TMPro;
using UnityEngine;

public class ItemTile : MonoBehaviour{

    Item item;

    public void Init(Item item){

        this.item = item;
        UpdateVisuals();

    }

    public void UpdateVisuals(){

        gameObject.GetComponentInChildren<TMP_Text>().text = item.Name;

    }

}
