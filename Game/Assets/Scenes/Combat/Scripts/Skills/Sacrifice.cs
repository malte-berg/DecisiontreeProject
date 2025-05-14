using UnityEngine;
using System;
using System.Collections.Generic;

public class Sacrifice : Skill {

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
        description: "Inflict damage on yourself to gain mana.",
        soundEffect: Resources.Load<AudioClip>("Sounds/sacrifice_sound")
        
        ){

    }

    public override bool Effect(GameCharacter target){

        int selfDmg = (int)(gc.Strength * 0.1f + gc.Magic * 0.15f);

        if(target.HP < selfDmg)
            return false;

        target.HP -= selfDmg;
        target.Mana += (int)(selfDmg * power);

        if(target.Mana > target.MaxMana)
            target.Mana = target.MaxMana;

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
        sm.RollScales(AbilityContainer, Vector3.zero, 10, 0.18f, 0.8f, false, false, 10);
    }
}
