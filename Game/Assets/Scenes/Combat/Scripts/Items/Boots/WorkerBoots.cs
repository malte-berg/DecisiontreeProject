using UnityEngine;

public class WorkerBoots : Boots{

    public WorkerBoots() : base(

        sprite: Resources.Load<Sprite>("Sprites/Items/workerBoots"),
        name: "Worker Boots",
        value: 12,
        description: "Worn and used, these boots should protect you from the weathers.",
        vitalityAdd: 5,
        vitalityMult: 1f,
        armorAdd: 1,
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