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
    private Item[] onSaleItems = new Item[2]; // 2 item för test
    private Item selectedItem;

    void Awake()
    {
        SetGold();
        Init();
    }

    void Init()
    {
        TestItems();
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
            "Sword",
            450,
            0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f, 0, 1.0f 
        );

        onSaleItems[1] = new Head(
            "Head",
            300,
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