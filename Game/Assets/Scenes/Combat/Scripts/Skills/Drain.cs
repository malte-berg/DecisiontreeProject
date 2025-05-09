using UnityEngine;

public class Drain : Skill
{


    public Drain() : base(
        icon: null,
        sprites: null,
        gc: null,
        name: "Drain",
        power: 1,
        manaCost: 20,
        skillCost: 1,
        cooldown: 2,
        attack: true,
        description: "Reduces enemy's Mana"
    )
    {

    }

    public override bool Effect(GameCharacter target)
    {
        int manaDrained = Mathf.Max(1, Mathf.RoundToInt(0.10f * target.Mana * power));
        int finalManaDrained = Mathf.Clamp(manaDrained, 0, target.Mana);


        Debug.Log("Before MANA: " + target.Mana);
        
        target.Mana -= manaDrained;

        Debug.Log("After MANA: " + target.Mana);


        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {
        // Optional: put animation logic here
        Debug.Log("Drain animation not implemented yet.");
    }

}
