using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill {
    
    public Heal() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/Heal_Icon"),
        sprites: new List<Sprite>{Resources.Load<Sprite>("Sprites/Abilities/heal")},
        gc: null,
        name: "Heal",
        power: 0,
        manaCost: 15,
        skillCost: 1,
        description: "Regain some lost health."
        
        ){
    }

    public override bool Effect(GameCharacter target){
        if (target != gc) {
            return false;
        }

        if(target.Mana < manaCost)
            return false;

        target.Mana -= manaCost;

        target.HP += Mathf.FloorToInt(gc.Magic * power);

        if (target.HP > target.Vitality){
            target.HP = target.Vitality;
        }

        return true;
    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm) {
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];

        sm.SetSprite(this.sprites[0], AbilityRenderer);        
        sm.HideSprite(AbilityRenderer);

        sm.SetScale(AbilityRenderer.transform, 1.6f);
        sm.ChangeOpacity(AbilityRenderer, 1f);

        Transform tr = AbilityRenderer.gameObject.transform;

        sm.RollScales(tr, Vector3.zero, 10, 0.4f, 0.96f, true, true, false, 10);
    }


}
