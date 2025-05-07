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
        power: 3,
        manaCost: 0,
        skillCost: 1,
        description: "Makes enemy attack other enemies"
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
        if (target == gc)
            return false;

        if (!gc.SpendMana(manaCost))
            return false;


        //Enemy targets another enemy instead of the player.
        var enemies = target.c.Enemies;

        // Debug Check if we have enemies
        Debug.Log("Enemies list count: " + enemies?.Count);

        if (enemies == null || enemies.Count <= 1) //just make sure we have more than 1 enemy
        {
            Debug.Log("not enough enemies to control");
            return false;
        }

        if (target is Enemy e)
        {

            Enemy enemyTarget = GetRandomEnemy(e, enemies); // This is the enemy that the mindcontrolled enemy targets.
            if (enemyTarget == null)
            {
                Debug.Log("could not choose random enemy");
                return false;
            }
            e.targetedByControlled = enemyTarget;

            int turn = 1; // how many turns enemy is mindcontrolled
            turn = Mathf.FloorToInt(turn * power);

            e.controlledTurns = turn;

            Debug.Log(e.CName + " is now targeting " + enemyTarget.CName);
        }


        return true;

    }

    public override void SkillAnimation(Vector3 targetPos, GameCharacter sender, SpriteManager sm)
    {

        Debug.Log("Animation not implemented yet.");
    }

}