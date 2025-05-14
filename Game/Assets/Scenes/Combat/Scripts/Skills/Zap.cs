using UnityEngine;
using System;
using System.Linq;

public class Zap : Skill
{

    public Zap() : base(
        icon: null,
        sprites: Resources.LoadAll<Sprite>("Sprites/Abilities/zap").ToList(),
        gc: null,
        name: "Zap",
        power: 1,
        manaCost: 30,
        skillCost: 1,
        cooldown: 2,
        attack: true,
        description: "Steals enemy's health while dealing damage",
        soundEffect: null
        )
    {

    }

    public override bool Effect(GameCharacter target)
    {


        // Add 10% of enemies health to player.
        int healAmount = (int)Math.Floor(target.HP * 0.1 * power);

        gc.HP = Mathf.Clamp(gc.HP + healAmount, 0, gc.Vitality);
        
        //Target takes damage.
        int damageDealt = Mathf.FloorToInt(gc.Strength * power);

        target.TakeDamage(Mathf.FloorToInt(damageDealt));

        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){
        float delay = 0.1f;
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;

        sm.SetScale(AbilityRenderer.transform, 3f);

        sm.RollSprites(sprites, AbilityRenderer, delay);

        sm.DisplaceSprite(targetPos + Vector3.up * 1.5f, AbilityContainer, delay);
        sm.DelayedAction(() => sm.HideSprite(AbilityRenderer), delay*sprites.Count - 0.1f);

        Vector3 toTarget = targetPos - sender.transform.position;

        sm.AttackAnimation(sender);
        sm.LungeTo(sender, toTarget * 0.05f, 0.2f);        

    }
}
