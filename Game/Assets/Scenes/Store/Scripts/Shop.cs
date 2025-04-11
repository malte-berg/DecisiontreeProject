using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [Header("UI")]
    public GameObject itemButtonPrefabs;
    public GameObject detailPanel;
    public TextMeshProUGUI GoldText;
    public Button buyButton;
    public Transform content;
    ItemButton itemButton;

    // Data
    Player player;
    int playerGold;

    // Test Demo använder först tillfälliga item. I den färdig versionen skulle man kunna sälja den givna itemarrayen enligt spelets framsteg.
    public Item[] onSaleItems; // 2 item för test
    // private Item selectedItem;

    void Awake()
    {
        SetGold();
        /* AreaData data = AreaDataLoader.Load(player.CurrentAreaIndex);
        if (data == null)
        {
            Debug.Log("AreaData is null");
        } else {
            Debug.Log("AreaData is not null");
        } */
        Init();
    }

    void Init()
    {
        // TestItems();
        LoadItems();

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(OnBuyButtonClick);
        
        ShowDetailPanel(false, null);
        UpdateGoldText();
    }
    
     void SetGold(){
        player = GameObject.Find("Player").GetComponent<Player>(); // finns kanske utrymme för optimering
        player.HidePlayer();
        playerGold = player.Gold; 
    }

    void LoadItems()
    {
        onSaleItems = AreaDataLoader.GetAreaItems(player.CurrentAreaIndex);
        
        if (onSaleItems == null) {
            Debug.Log("onSaleItems is null");
            return; 
        }

        for (int i = 0; i < onSaleItems.Length; i++)
        {
            itemButton = Instantiate(itemButtonPrefabs, content).GetComponent<ItemButton>();
            itemButton.Init(onSaleItems[i], this);
        }
    }
    void TryBuyItem()
    {
        if (itemButton == null) return;
        int value = itemButton.currentItem.Value;

        if (playerGold >= value)
        {
            playerGold -= value;
            player.Gold = playerGold;
            itemButton.ButtonClose();
            UpdateGoldText();
        }
    }
    void TestItems()
    {
        onSaleItems[0] = new Weapon(
            null,
            "Sword",
            450, "swrd", 
            0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f 
        );

        onSaleItems[1] = new Head(
            null,
            "Head",
            300, "hed",
            0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f
        );

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