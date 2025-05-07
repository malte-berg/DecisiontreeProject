using UnityEngine;

public class Corrode : Skill
{
    public Corrode() : base(
      icon: null,
      sprites: null,
      gc: null,
      name: "Corrode",
      power: 1,
      manaCost: 0,
      skillCost: 1,
      description: "Reduces enemy armor"
      )
    {

    }


    public override bool Effect(GameCharacter target)
    {

        if (target == gc)
            return false;
        if (!gc.SpendMana(manaCost))
            return false;

        //Target's "Armor" stat decreases.
        int armorCorroded = 5; // amount of armor lost temporarily

        int corrodeTurns = Mathf.FloorToInt(power); // made this for clarity purpose, power decides turns for now.




        //Debug.Log("Raw armor base: " + target.armor);
        Debug.Log("Effect sum: " + target.GetEffectSum(1));
        Debug.Log("Effect mult: " + target.GetEffectFactor(1));
        Debug.Log("Final Armor: " + target.Armor);

        //target.statusEffects.Add(new StatusEffect(corrodeTurns, armorCorroded, power, 1));
        ModifyStatusEffect(target.statusEffects, corrodeTurns, armorCorroded, power, 1);


        //Debuff.DebuffStat(target, "armor", -20);
        //Debug.Log("Debuff: " + target.GetDebuffAdd("armor"));
        Debug.Log("Effect sum after: " + target.GetEffectSum(1));
        Debug.Log("Effect mult after: " + target.GetEffectFactor(1));
        Debug.Log("Final Armor after corrosion: " + target.Armor);

        //Debug.Log("Corrode gives target an armor of: " + target.Armor);

        return true;
    }
    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Corrode animation not implemented yet.");
    }


}





