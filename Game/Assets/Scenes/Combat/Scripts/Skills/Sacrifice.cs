using UnityEngine;
using System;
using System.Collections.Generic;

public class Sacrifice : Skill {

    int selfDamage;

    public Sacrifice() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/Sacrifice_Icon"),
        sprites: new List<Sprite>{Resources.Load<Sprite>("Sprites/Abilities/sacrifice")},
        gc: null, 
        name: "Sacrifice", 
        power: 0, 
        manaCost: 0, 
        skillCost: 1,
        cooldown: 0,
        attack: false,
        description: "Inflict damage on yourself to gain mana"
        
        ){

        this.selfDamage = 10;
        
    }

    public override bool Effect(GameCharacter target){

        if(target.HP < selfDamage)
            return false;

        target.Mana += 10 + (int)Math.Floor((0.9 * gc.Strength) * (0.1 * gc.Magic) * power);

        if(target.Mana > target.MaxMana) {
            target.Mana = target.MaxMana;
        }

        target.HP -= Mathf.FloorToInt(selfDamage/(gc.Strength * power));

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm) {
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;

        sm.SetSprite(this.sprites[0], AbilityRenderer);
        sm.HideSprite(AbilityRenderer);

        sm.ChangeOpacity(AbilityRenderer, 1f);
        sm.SetScale(AbilityRenderer.transform, 1.3f);

        sm.AttackAnimation(sender);
        sm.RollScales(AbilityContainer, Vector3.zero, 15, 0.4f, 1.25f, false, false, true, 4);
    }
}
