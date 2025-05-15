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
        manaCost: 20,
        skillCost: 1,
        cooldown: 2,
        attack: false,
        description: "Add some armor to player.",
        soundEffect: new AudioClip[] {
            Resources.Load<AudioClip>("Sounds/shield_sound")
        }
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

        SpriteRenderer AbilityRenderer = sm.spriteLayers["ShadowBehind"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;

        int len = sender.statusEffects.Count;
        for(int i = 0; i < len; i++) {
            StatusEffect eff = sender.statusEffects[i];
            if(eff.EffectType == 1) {
                if(eff.Turns > 0) {
                    sm.SetSprite(this.sprites[0], AbilityRenderer);
                    sm.ChangeOpacity(AbilityRenderer, 0.4f);
                    AbilityRenderer.sortingOrder = 1000;
                    if(eff.Turns == 2) {
                        AbilityContainer.localScale = new Vector3(0.72f, 0.5f, 1f);
                        sm.HideSprite(AbilityRenderer);
                        sm.RollScales(AbilityContainer, Vector3.zero, 4, 0.2f, 1.26f, false, false, 4);
                        sm.AttackAnimation(sender);
                        sm.DelayedAction(() => sm.ShowSprite(AbilityRenderer), 0.4f);
                    }
                    return;
                }
            }
        }
        sm.AddShadow();
        AbilityContainer.localScale = Vector3.one;
        AbilityRenderer.sortingOrder = 0;
    }

}
