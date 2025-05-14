using UnityEngine;
using System.Linq;

public class Corrode : Skill
{
    public Corrode() : base(
      icon: Resources.Load<Sprite>("Sprites/Abilities/corrode_Icon"),
      sprites: Resources.LoadAll<Sprite>("Sprites/Abilities/corrode").ToList(),
      gc: null,
      name: "Corrode",
      power: 1,
      manaCost: 25,
    //   manaCost: 0, //debug
      skillCost: 1,
      cooldown: 2,
      attack: true,
      description: "Reduces enemy armor"
      )
    {

    }


    public override bool Effect(GameCharacter target)
    {

        int armorCorroded = 10;       
        armorCorroded = Mathf.Clamp(armorCorroded, 0, target.Armor); 

        int corrodeTurns = Mathf.FloorToInt( 2* power); // made this for clarity purpose, power decides turns for now.

        target.statusEffects.Add(new StatusEffect(corrodeTurns, armorCorroded, power, 1));
        
        return true;
    }
    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){
        float delay = 0.11f;
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;
        sm.ChangeOpacity(AbilityRenderer, 1f);

        float totalDelay = delay*sprites.Count;

        AbilityRenderer.enabled = true;
        sm.SetSprite(null, AbilityRenderer);
        AbilityContainer.localScale = new Vector3(1.8f, 2.7f, 1);

        sm.RollSprites(sprites, AbilityRenderer, delay);
        sm.DelayedAction(() => sm.SetSprite(sprites[8], AbilityRenderer), delay*sprites.Count);

        sm.DisplaceSprite(targetPos + Vector3.up * -0.05f + Vector3.right * -0.1f, AbilityContainer, totalDelay);
        sm.DelayedAction(() => sm.HideSprite(AbilityRenderer), totalDelay);

        Vector3 toTarget = targetPos - sender.transform.position;

        sm.AttackAnimation(sender);
        sm.LungeTo(sender, toTarget * 0.05f, 0.2f); 
    }


}





