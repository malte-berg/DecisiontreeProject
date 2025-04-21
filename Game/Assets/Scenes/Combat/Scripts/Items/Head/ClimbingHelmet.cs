using UnityEngine;

public class ClimbingHelmet : Head{

    public ClimbingHelmet() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/climbingHelmet_Icon"),
        sprite: Resources.Load<Sprite>("Sprites/Items/climbingHelmet"),
        name: "Climbing Helmet",
        value: 18,
        description: "Good protection in case you bang your head against a hard place.",
        vitalityAdd: 5,
        vitalityMult: 1.002f,
        armorAdd: 2,
        armorMult: 1.01f,
        strengthAdd: 2,
        strengthMult: 1f,
        magicAdd: 1,
        magicMult: 1f,
        manaAdd: 3,
        manaMult: 1f
        
    ) {
        
    }

}