using UnityEngine;

public class GladiatorHelmet : Head{
    public GladiatorHelmet() : base(
        
        icon: Resources.Load<Sprite>("Sprites/Icons/gladiatorHelmet_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/gladiatorHelmet"),
        name: "Warrior Helmet",
        value: 200,
        description: "SPARTAA!!",
        vitalityAdd: 26,
        vitalityMult: 1.008f,
        armorAdd: 10,
        armorMult: 1f,
        strengthAdd: 5,
        strengthMult: 1.01f,
        magicAdd: 4,
        magicMult: 1f,
        manaAdd: 6,
        manaMult: 1f
        
    ) {
        
    }

}