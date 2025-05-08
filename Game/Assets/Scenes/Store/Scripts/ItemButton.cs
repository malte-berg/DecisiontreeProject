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
    private Sprite iconImage;

    void Awake()
    {
        detailPanel = GameObject.Find("ItemDetail")?.GetComponent<TextMeshProUGUI>();
        //priceText = transform.Find("PriceText")?.GetComponent<TextMeshProUGUI>();
        priceText = transform.GetChild(0)?.GetComponent<TextMeshProUGUI>();
    }

    public void Init(Item item, Shop s)
    {
        // to use feature from shop
        this.s = s;

        currentItem = item;
        priceText.text = item.Value.ToString();

        if (s.IsItemPurchased(currentItem))
        {
            ButtonClose();
        }
        // set icon for items
        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = item.icon;

        //GetComponent<Button>().onClick.AddListener(OnItemClicked);
        btn.onClick.AddListener(OnItemClicked);
    }

    void DisplayItemDetail() {
        string description = $"<size=18><u>{currentItem.Name}</u><br><size=12>{currentItem.Description}<br><br>";

        switch(currentItem){

            case Head:
                Head head = currentItem as Head;
                description += $"<color=green>Vitality: \t{CalcAdd(head.VitalityAdd)} ({CalcMult(head.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(head.ArmorAdd)} ({CalcMult(head.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(head.StrengthAdd)} ({CalcMult(head.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(head.MagicAdd)} ({CalcMult(head.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(head.ManaAdd)} ({CalcMult(head.ManaMult)})</color>\n";
                break;
            case Torso:
                Torso torso = currentItem as Torso;
                description += $"<color=green>Vitality: \t{CalcAdd(torso.VitalityAdd)} ({CalcMult(torso.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(torso.ArmorAdd)} ({CalcMult(torso.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(torso.StrengthAdd)} ({CalcMult(torso.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(torso.MagicAdd)} ({CalcMult(torso.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(torso.ManaAdd)} ({CalcMult(torso.ManaMult)})</color>\n";
                break;
            case Boots:
                Boots boots = currentItem as Boots;
                description += $"<color=green>Vitality: \t{CalcAdd(boots.VitalityAdd)} ({CalcMult(boots.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(boots.ArmorAdd)} ({CalcMult(boots.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(boots.StrengthAdd)} ({CalcMult(boots.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(boots.MagicAdd)} ({CalcMult(boots.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(boots.ManaAdd)} ({CalcMult(boots.ManaMult)})</color>\n";
                break;
            case Weapon:
                Weapon weapon = currentItem as Weapon;
                description += $"<color=green>Vitality: \t{CalcAdd(weapon.VitalityAdd)} ({CalcMult(weapon.VitalityMult)})</color>\n";
                description += $"<color=orange>Armor: \t{CalcAdd(weapon.ArmorAdd)} ({CalcMult(weapon.ArmorMult)})</color>\n";
                description += $"<color=red>Strength: \t{CalcAdd(weapon.StrengthAdd)} ({CalcMult(weapon.StrengthMult)})</color>\n";
                description += $"<color=blue>Magic: \t{CalcAdd(weapon.MagicAdd)} ({CalcMult(weapon.MagicMult)})</color>\n";
                description += $"<color=purple>Mana: \t{CalcAdd(weapon.ManaAdd)} ({CalcMult(weapon.ManaMult)})</color>\n";
                break;
            case Consumable:
                // TODO
                break;
            default:
                Debug.LogError("No item type found");
                break;

        }

        detailPanel.text = description;

    }

    private string CalcAdd(int statAdd) {
        return $"{(statAdd < 0 ? "" : "+")}{statAdd}";
    }

    private string CalcMult(float statMult) {
        return $"{(statMult < 1 ? "" : "+")}{statMult*100-100:F1}%";
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
