using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [Header("UI")]
    public GameObject itemButtonPrefabs;
    //public Transform itemsParent;
    public GameObject detailPanel;
    public TextMeshProUGUI GoldText;
    public Button buyButton;
    public Transform content;
    ItemButton itemButton;

    // Data
    int playerGold = 2000;
    private List<Item> allItems = new List<Item>();
    private Item selectedItem;

    void Start()
    {
        Init();
    }

    void Init()
    {
        TestItems();
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(OnBuyButtonClick);
        for (int i = 0; i < allItems.Count; i++)
        {
            itemButton = Instantiate(itemButtonPrefabs, content).GetComponent<ItemButton>();
            itemButton.Init(allItems[i], this);
        }
        ShowDetailPanel(false, null);
        UpdateGoldText();
    }


    void TryBuyItem()
    {
        if (itemButton == null) return;
        int value = itemButton.currentItem.GetValue();

        if (playerGold >= value)
        {
            playerGold -= value;
            itemButton.ButtonClose();
            UpdateGoldText();
        }
    }
    void TestItems()
    {
        allItems.Add(new Weapon(
            "Sword",
            450
        ));

        allItems.Add(new Head(
            "Head",
            300
        ));

    }

    void UpdateGoldText()
    {
        GoldText.text = "Gold: " + playerGold;
    }

    public void ShowDetailPanel(bool show, ItemButton btn)
    {
        detailPanel.SetActive(show);
        itemButton = btn;
    }

    public void OnBuyButtonClick()
    {
        TryBuyItem();
        UpdateGoldText();
    }

}

/* void TestItems()
    {
        allItems.Add(new ShopItem(
            "Sword",
            450,
            "Attack: +15",
            "This is a sword."
        ));

        allItems.Add(new ShopItem(
            "Armor",
            300,
            "Armor: +20",
            "This is armor"
        ));

    }

public class ShopItem
    {
        public string itemName;
        public int value;
        public string stats;
        public string story;

        public ShopItem(string name, int value, string stats, string story)
        {
            this.itemName = name;
            this.value = value;
            this.stats = stats;
            this.story = story;
        }
    } */