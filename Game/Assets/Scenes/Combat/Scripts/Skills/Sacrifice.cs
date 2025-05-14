using UnityEngine;
using System.Linq;

public class Sacrifice : Skill {

    public Sacrifice() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/sacrifice_Icon"),        
        sprites: Resources.LoadAll<Sprite>("Sprites/Abilities/sacrifice").ToList(),
        gc: null, 
        name: "Sacrifice", 
        power: 0, 
        manaCost: 0, 
        skillCost: 1,
        cooldown: 0,
        attack: false,
        description: "Inflict damage on yourself to gain mana."
        
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
        float delay = 0.1f;
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;
        sm.ChangeOpacity(AbilityRenderer, 3f);

        float totalDelay = delay*sprites.Count + 0.15f;

        AbilityRenderer.enabled = true;
        sm.SetSprite(null, AbilityRenderer);
        AbilityContainer.localScale = new Vector3(1.8f, 2.6f, 1f);

        sm.RollSprites(sprites, AbilityRenderer, delay);
        sm.DelayedAction(() => sm.SetSprite(sprites[8], AbilityRenderer), delay*sprites.Count);

        // sm.DisplaceSprite(targetPos + Vector3.up * -0.05f + Vector3.right * 0.1f, AbilityContainer, totalDelay);
        sm.DelayedAction(() => sm.HideSprite(AbilityRenderer), totalDelay);

        Vector3 toTarget = targetPos - sender.transform.position;

        sm.AttackAnimation(sender);
    }
}
