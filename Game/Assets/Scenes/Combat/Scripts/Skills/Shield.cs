using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill
{

    public Shield() : base(
         icon: Resources.Load<Sprite>("Sprites/Abilities/shield_Icon"),
         sprites: new List<Sprite>{Resources.Load<Sprite>("Sprites/Abilities/shield")},
         gc: null,
         name: "Shield",
         power: 1,
         manaCost: 25,
         skillCost: 1,
         cooldown: 2,
         attack: false,
         description: "Add some armor to player."
         )
    {

    }

    public override bool Effect(GameCharacter target)
    {

        int shieldAdded = -10; // amount of armor gained temporarily

        int shieldTurns = Mathf.FloorToInt( 2 * power); // made this for clarity purpose, power decides turns for now.

        //Add armor to the player character.
        target.statusEffects.Add(new StatusEffect(shieldTurns, shieldAdded, power, 1));

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;

        sm.SetSprite(this.sprites[0], AbilityRenderer);
        sm.HideSprite(AbilityRenderer);

        sm.ChangeOpacity(AbilityRenderer, 0.4f);
        AbilityContainer.localScale = new Vector3(1.5f, 1.0f, 1f);

        sm.AttackAnimation(sender);
        sm.RollScales(AbilityContainer, Vector3.zero, 20, 0.8f, 1.26f, false, false, 4);
    }

}
