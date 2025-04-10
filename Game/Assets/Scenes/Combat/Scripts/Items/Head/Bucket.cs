
using UnityEngine;

public class Bucket : Head{
    public Bucket() : base(
        
        sprite: Resources.Load<Sprite>("Sprites/Items/Bucket"),
        name: "Bucket",
        value: 2,
        description: "Wha-? Why would you put that over your head?",
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