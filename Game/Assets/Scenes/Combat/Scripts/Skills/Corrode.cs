using UnityEngine;

public class Corrode : Skill
{
    public Corrode() : base(
      icon: null,
      sprites: null,
      gc: null,
      name: "Corrode",
      power: 1,
      manaCost: 25,
      skillCost: 1,
      cooldown: 2,
      attack: true,
      description: "Reduces enemy armor"
      )
    {

    }


    public override bool Effect(GameCharacter target)
    {

        int armorCorroded = 10;        
        if((armorCorroded * power) > target.Armor) // so we dont reduce armor below 0
        {
            armorCorroded = Mathf.Max(0, Mathf.FloorToInt(target.Armor / power));

        }

        int corrodeTurns = Mathf.FloorToInt( 2* power); // made this for clarity purpose, power decides turns for now.

        Debug.Log("Final Armor before: " + target.Armor);

        target.statusEffects.Add(new StatusEffect(corrodeTurns, armorCorroded, power, 1));
        
        Debug.Log("Final Armor after corrosion: " + target.Armor);


        return true;
    }
    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Corrode animation not implemented yet.");
    }


}





