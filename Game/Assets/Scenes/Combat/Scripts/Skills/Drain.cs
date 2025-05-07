using UnityEngine;

public class Drain : Skill
{


    public Drain() : base(
        icon: null,
        sprites: null,
        gc: null,
        name: "Drain",
        power: 1,
        manaCost: 0,
        skillCost: 1,
        description: "Reduces enemy's Mana"
    )
    {

    }

    public override bool Effect(GameCharacter target)
    {
        if (target == gc)
            return false;
        if (!gc.SpendMana(manaCost))
            return false;


        int manaDrained = 10 ; // amount of armor lost temporarily

        int drainTurns = Mathf.FloorToInt(power); // made this for clarity purpose, power decides turns for now.

        Debug.Log("Before MANA: " + target.Mana);
        
        target.statusEffects.Add(new StatusEffect(drainTurns, manaDrained, power, 4)); 

        Debug.Log("After MANA: " + target.Mana);


        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Corrode animation not implemented yet.");
    }

}
