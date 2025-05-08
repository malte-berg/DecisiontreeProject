using UnityEngine;

public class EnforcerHelmet : Head{
    public EnforcerHelmet() : base(
        
        icon: Resources.Load<Sprite>("Sprites/Icons/enforcerHelmet_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/enforcerHelmet"),
        name: "Guard Helmet",
        value: 70,
        description: "Maybe you can blend in with the guards",
        vitalityAdd: 12,
        vitalityMult: 1.002f,
        armorAdd: 4,
        armorMult: 1f,
        strengthAdd: 3,
        strengthMult: 1f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 3,
        manaMult: 1f
        
    ) {
        
    }

}