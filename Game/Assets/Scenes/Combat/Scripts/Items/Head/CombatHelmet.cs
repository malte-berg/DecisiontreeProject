using UnityEngine;

public class CombatHelmet : Head{

    public CombatHelmet() : base(

        sprite: Resources.Load<Sprite>("Sprites/Items/combatHelmet"),
        name: "Combat Helmet",
        value: 50,
        description: "Now this could perhaps even stop shrapnel.",
        vitalityAdd: 8,
        vitalityMult: 1.003f,
        armorAdd: 3,
        armorMult: 1f,
        strengthAdd: 6,
        strengthMult: 1.001f,
        magicAdd: 3,
        magicMult: 1.01f,
        manaAdd: 2,
        manaMult: 1f
        
    ) {
        
    }

}