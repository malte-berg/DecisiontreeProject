using UnityEngine;

public class BicycleHelmet : Head{

    public BicycleHelmet() : base(

        sprite: Resources.Load<Sprite>("Sprites/Items/bicycleHelmet"),
        name: "Bicycle Helmet",
        value: 12,
        description: "It was a long time ago you last rode a bike, but the protective gear is still here.",
        vitalityAdd: 4,
        vitalityMult: 1f,
        armorAdd: 2,
        armorMult: 1f,
        strengthAdd: 0,
        strengthMult: 1f,
        magicAdd: 0,
        magicMult: 1f,
        manaAdd: 0,
        manaMult: 1f
        
    ) {
        
    }

}