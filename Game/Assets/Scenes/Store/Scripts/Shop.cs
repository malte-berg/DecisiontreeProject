using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Shop : MonoBehaviour
{
    [Header("UI")]
    public GameObject itemButtonPrefabs;
    public GameObject detailPanel;
    public TextMeshProUGUI GoldText;
    public Button buyButton;
    public Transform content;
    private ItemButton itemButton;

    private int inventoryIndex;
    // Data
    private Player player;
    private int playerGold;

    // Test Demo använder först tillfälliga item. I den färdig versionen skulle man kunna sälja den givna itemarrayen enligt spelets framsteg.
    public Item[] onSaleItems; // 2 item för test
    // private Item selectedItem;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        // TestItems();
        DataFromPlayer();
        LoadItems();

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(OnBuyButtonClick);

        ShowDetailPanel(false, null);
        UpdateGoldText();
    }

    void DataFromPlayer()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // finns kanske utrymme för optimering
        player.HidePlayer();
        playerGold = player.Gold;
        inventoryIndex = 0;
        // find the first empty space of the player inventory (array)
        while (inventoryIndex < player.inventory.Length && player.inventory[inventoryIndex] != null)
        {
            inventoryIndex++;
        }
        Debug.Log("inventoryIndex: " + inventoryIndex);
    }

    void LoadItems()
    {
        onSaleItems = AreaDataLoader.GetAreaItems(player.CurrentAreaIndex);

        if (onSaleItems == null)
        {
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

        if (playerGold >= value && inventoryIndex < player.inventory.Length)
        {
            playerGold -= value;
            player.Gold = playerGold;
            // the player inventory is a fixed-size array
            player.inventory[inventoryIndex++] = itemButton.currentItem;
            itemButton.ButtonClose();
            // close buyButton
            buyButton.interactable = false;
            UpdateGoldText();
        }
    }

    public Boolean IsItemPurchased(Item selectItem)
    {
        // itemButton.currentItem.Name;
        int i = 0;
        while (player.inventory[i] != null)
        {
            if (player.inventory[i].Name == selectItem.Name)
            {
                return true;
            }
            i++;
        }

        return false;
    }

    void UpdateGoldText()
    {
        GoldText.text = "Gold: " + playerGold;
    }

    public void ShowDetailPanel(bool show, ItemButton btn)
    {
        detailPanel.SetActive(show);
        // activate buyButton
        buyButton.interactable = true;
        itemButton = btn;
    }

    public void OnBuyButtonClick()
    {
        TryBuyItem();
        UpdateGoldText();
    }

}