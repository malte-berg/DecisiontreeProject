using UnityEngine;

public class Corrode : Skill
{
    GameCharacter gc;

    public Corrode(GameCharacter gc) : base(
        sprites: null,
        gc: gc,
        name: "Corrode",
        power: 1,
        manaCost: 0,
        skillCost: 1,
        description: "Reduces enemy armor"
        )
    {
        this.gc = gc;
    }


    public override bool Effect(GameCharacter target)
    {

        if (target == gc)
            return false;
        if (gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        //Target's "Armor" stat decreases.
        int armorCorroded = Mathf.FloorToInt(5 * power); // amount of armor lost temporarily
        //Debug.Log("Raw armor base: " + target.armor);
        Debug.Log("Equip sum: " + target.GetEquipmentArmorSum());
        Debug.Log("Equip mult: " + target.GetEquipmentArmorMult());
        Debug.Log("Debuff: " + target.GetDebuffAdd("armor"));
        Debug.Log("Final Armor: " + target.Armor);


        Debuff.DebuffStat(target, "armor", -20);

        //Debug.Log("Raw armor base: " + target.armor);
        Debug.Log("Equip sum: " + target.GetEquipmentArmorSum());
        Debug.Log("Equip mult: " + target.GetEquipmentArmorMult());
        Debug.Log("Debuff: " + target.GetDebuffAdd("armor"));
        Debug.Log("Final Armor: " + target.Armor);

        //Debug.Log("Corrode gives target an armor of: " + target.Armor);

        return true;
    }
}





