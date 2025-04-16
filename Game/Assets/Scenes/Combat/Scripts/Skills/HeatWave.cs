using UnityEngine;
using System.Collections.Generic;

public class HeatWave : Skill {

    public HeatWave() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/HeatWave_Icon"),
        sprites: new List<Sprite>{Resources.Load<Sprite>("Sprites/Abilities/heatwave")},
        gc: null, 
        name: "Heat Wave", 
        power: 0, 
        manaCost: 0, 
        skillCost: 1,
        description: "Deal Fire Damage to all enemies."
        
        ){

    }

    public override bool Effect(GameCharacter target) {
        if(target == gc)
            return false;
        if(gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt(gc.Magic * power);

        Combat combat = target.c;
        List<Enemy> enemies = combat.Enemies;

        foreach (GameCharacter enemy in enemies){
            enemy.TakeDamage(Mathf.FloorToInt(damageDealt));
        }

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm) {
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;

        sm.SetSprite(this.sprites[0], AbilityRenderer);
        sm.ChangeOpacity(AbilityRenderer, 1f);

        Vector3 toTarget = targetPos - sender.transform.position; 

        sm.AttackAnimation(sender);
        sm.LungeTo(sender, toTarget * 0.05f, 0.2f);
        sm.RollScales(AbilityContainer, toTarget * 0.95f, 10, 0.4f, true, false, false);
    }

}
