using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MindControl : Skill
{

    public static System.Random rand = new System.Random();

    public MindControl() : base(
        icon: Resources.Load<Sprite>("Sprites/Abilities/mindControl_Icon"),
        sprites: Resources.LoadAll<Sprite>("Sprites/Abilities/mindControl").ToList(),
        gc: null,
        name: "Mind Control",
        power: 1,
        // manaCost : 0, // for debug
        manaCost: 30,
        skillCost: 1,
        cooldown: 2, 
        attack: true,
        description: "Hijacks enemy's mind, making them unable to tell friend from foe",
        soundEffect: null
        )
    {

    }

    public static Enemy GetRandomEnemy(Enemy currentEnemy, List<Enemy> Enemies)
    {
        if (Enemies == null || Enemies.Count <= 1)
        {
            return null;
        }

        int currentIndex = Enemies.IndexOf(currentEnemy);
        int randomIndex;

        do
        {
            randomIndex = rand.Next(Enemies.Count);
        } while (randomIndex == currentIndex);

        return Enemies[randomIndex];
    }



    public override bool Effect(GameCharacter target)
    {
  
        //Enemy targets another enemy instead of the player.
        List<Enemy> enemies = target.c.Enemies;

        if (enemies == null || enemies.Count <= 1) //just make sure we have more than 1 enemy
        {
            return false;
        }

        if (target is Enemy e)
        {

            Enemy enemyTarget = GetRandomEnemy(e, enemies); // This is the enemy that the mindcontrolled enemy targets.
            if (enemyTarget == null)
            {
                return false;
            }
            e.targetedByControlled = enemyTarget;

            int turn = 1; // how many turns enemy is mindcontrolled
            turn = Mathf.Min(4, Mathf.RoundToInt(turn * power * 1.15f));
  
            e.controlledTurns = turn;
        }


        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){
        float delay = 0.12f;
        SpriteRenderer AbilityRenderer = sm.spriteLayers["Ability"];
        Transform AbilityContainer = AbilityRenderer.gameObject.transform;

        float totalDelay = delay*sprites.Count + 0.2f;

        AbilityRenderer.enabled = true;
        sm.SetSprite(null, AbilityRenderer);
        sm.SetScale(AbilityRenderer.transform, 2.5f);

        sm.RollSprites(sprites, AbilityRenderer, delay);

        sm.DisplaceSprite(targetPos + Vector3.up * -0.5f + Vector3.right * 0.33f, AbilityContainer, totalDelay);
        sm.DelayedAction(() => sm.HideSprite(AbilityRenderer), totalDelay);

        Vector3 toTarget = targetPos - sender.transform.position;

        sm.AttackAnimation(sender);
        sm.LungeTo(sender, toTarget * 0.05f, 0.2f);  
    }

}