
using UnityEngine;

public class EnforcerHelmet : Head{
    public EnforcerHelmet() : base(
        
        icon: Resources.Load<Sprite>("Sprites/Icons/enforcerHelmet_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/enforcerHelmet"),
        name: "Guard Helmet",
        value: 2,
        description: "Maybe you can blend in with the guards",
        vitalityAdd: 1,
        vitalityMult: 1f,
        armorAdd: 7,
        armorMult: 1f,
        strengthAdd: -2,
        strengthMult: 0.9f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}