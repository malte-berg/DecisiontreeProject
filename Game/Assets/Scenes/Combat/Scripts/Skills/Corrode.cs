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
        armorCorroded = Mathf.Clamp(armorCorroded, 0, target.Armor); 

        int corrodeTurns = Mathf.FloorToInt( 2* power); // made this for clarity purpose, power decides turns for now.

        target.statusEffects.Add(new StatusEffect(corrodeTurns, armorCorroded, power, 1));
        
        return true;
    }
    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){}


}





