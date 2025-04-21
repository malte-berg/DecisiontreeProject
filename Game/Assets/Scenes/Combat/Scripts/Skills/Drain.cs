using UnityEngine;

public class Drain : Skill
{
    GameCharacter gc;

    public Drain(GameCharacter gc) : base(
        sprites: null,
        gc: gc,
        name: "Drain",
        power: 1,
        manaCost: 0,
        skillCost: 1,
        description: "Reduces enemy's Mana"
    )
    {
        this.gc = gc;
    }

    public override bool Effect(GameCharacter target)
    {
        if (target == gc)
            return false;
        if (!gc.SpendMana(manaCost))
            return false;

        int manaDrained = Mathf.FloorToInt(10 * power); // amount of armor lost temporarily

        // Debug.Log("Raw mana base: " + target.mana);
        Debug.Log("Equip sum: " + target.GetEquipmentManaSum());
        Debug.Log("Equip mult: " + target.GetEquipmentManaMult());
        Debug.Log("Debuff: " + target.GetDebuffAdd("mana"));
        Debug.Log("Final mana: " + target.Mana);

        //target.effects["mana"] = new Debuff(-manaDrained);
        Debuff.DebuffStat(target, "mana", -manaDrained);


        //Debug.Log("Raw mana base: " + target.mana);
        Debug.Log("Equip sum: " + target.GetEquipmentManaSum());
        Debug.Log("Equip mult: " + target.GetEquipmentManaMult());
        Debug.Log("Debuff: " + target.GetDebuffAdd("mana"));
        Debug.Log("Final mana: " + target.Mana);



        return true;

    }

}
