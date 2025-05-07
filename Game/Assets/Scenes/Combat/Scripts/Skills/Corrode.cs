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

        int armorCorroded = 5; // amount of armor lost temporarily
        
        if(armorCorroded > target.Armor) // so we dont reduce armor below 0
        {
            armorCorroded = target.Armor;
        }

        int corrodeTurns = Mathf.FloorToInt(power); // made this for clarity purpose, power decides turns for now.

        Debug.Log("Final Armor before: " + target.Armor);

        ModifyStatusEffect(target.statusEffects, corrodeTurns, armorCorroded, power, 1);
        
        Debug.Log("Final Armor after corrosion: " + target.Armor);


        return true;
    }
    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Corrode animation not implemented yet.");
    }


}





