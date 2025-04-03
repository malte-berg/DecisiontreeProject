using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemButton : MonoBehaviour
{
    Shop a;

    //
    private TextMeshProUGUI detailPanel;
    // item information
    public Item currentItem;
    private TextMeshProUGUI priceText;
    // private Image iconImage;
    // private string nameText;
    // private int value;
    // private string statsText;
    // private string storyText;

    void Awake()
    {
        detailPanel = GameObject.Find("ItemDetail")?.GetComponent<TextMeshProUGUI>();
        priceText = transform.Find("PriceText")?.GetComponent<TextMeshProUGUI>();
        if (priceText == null) Debug.LogWarning("PriceText not found in ItemButton prefab!");
    }

    public void Init(Item item, Shop a)
    {
        // för att kunna använda funktion från Shop
        this.a = a;

        currentItem = item;
        priceText.text = item.GetValue().ToString();

        /* value = item.value;
        nameText = item.itemName;
        statsText = item.stats;
        storyText = item.story; */

        // iconImage.sprite = ...

        GetComponent<Button>().onClick.AddListener(OnItemClicked);
    }

    void DisplayItemDetail()
    {
        detailPanel.text = currentItem.GetNamn() + "\n"; //+ currentItem.stats + "\n" + currentItem.story;
    }

    public void ButtonClose()
    {
        this.GetComponent<Button>().interactable = false; 
    }
    private void OnItemClicked()
    {
        DisplayItemDetail();
        a.ShowDetailPanel(true,this);
    } 

}
