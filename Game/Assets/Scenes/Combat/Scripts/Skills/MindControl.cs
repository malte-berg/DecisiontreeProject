using UnityEngine;
using System.Collections.Generic;

public class MindControl : Skill
{

    public static System.Random rand = new System.Random();

    public MindControl() : base(
        icon: null,
        sprites: null,
        gc: null,
        name: "Mind Control",
        power: 1,
        manaCost: 30,
        skillCost: 1,
        cooldown: 2, 
        attack: true,
        description: "Hijacks enemy's mind, making them unable to tell friend from foe"
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

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm){}

}