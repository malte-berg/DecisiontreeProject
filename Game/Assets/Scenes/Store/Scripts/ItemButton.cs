using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemButton : MonoBehaviour
{
    Shop s;

    public Button btn;
    // item information
    private TextMeshProUGUI detailPanel;
    public Item currentItem;
    private TextMeshProUGUI priceText;
    // private Image iconImage;

    void Awake()
    {
        detailPanel = GameObject.Find("ItemDetail")?.GetComponent<TextMeshProUGUI>();
        //priceText = transform.Find("PriceText")?.GetComponent<TextMeshProUGUI>();
        priceText = transform.GetChild(0)?.GetComponent<TextMeshProUGUI>();
    }

    public void Init(Item item, Shop s)
    {
        // för att kunna använda funktion från Shop
        this.s = s;

        currentItem = item;
        priceText.text = item.Value.ToString();

        if (s.IsItemPurchased(currentItem))
        {
            ButtonClose();
        }

        // iconImage.sprite = ...

        //GetComponent<Button>().onClick.AddListener(OnItemClicked);
        btn.onClick.AddListener(OnItemClicked);
    }

    void DisplayItemDetail()
    {
        detailPanel.text = currentItem.Name + "\n\n" + currentItem.Description;
        //"The item's story or attributes can displayed here."; 
    }

    public void ButtonClose()
    {
        this.GetComponent<Button>().interactable = false;
    }

    private void OnItemClicked()
    {
        DisplayItemDetail();
        s.ShowDetailPanel(true, this);
    }

}
