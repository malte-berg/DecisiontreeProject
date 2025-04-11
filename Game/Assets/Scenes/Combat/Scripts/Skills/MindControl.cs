using UnityEngine;

//  We could not find a good way to make this work...
public class MindControl : Skill
{
    GameCharacter gc;

    System.Random rand = new System.Random();

    public MindControl(GameCharacter gc) : base(
        sprites: null,
        gc: gc,
        name: "Mind Control",
        power: 2,
        manaCost: 0,
        skillCost: 1,
        description: "Makes enemy attack other enemies"
        )
    {
        this.gc = gc;
    }


    public override bool Effect(GameCharacter target)
    {
        if (target == gc)
            return false;
        if (gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;


        //Enemy targets another enemy, instead of the player.

        var enemies = target.c.Enemies;

        // Debug: Check if we have enemies
        Debug.Log("Enemies list count: " + enemies?.Count);

        if (enemies == null || enemies.Count <= 1) //just make sure we have more than 1 enemy
        {
            Debug.Log("not enough enemies to control");
            return false;
        }

        if (target is Enemy e)
        {
            int currentEnemyIndex = enemies.IndexOf(e);
            Debug.Log("Current enemy index: " + currentEnemyIndex);
            int randomEnemyIndex;
            do
            {
                randomEnemyIndex = rand.Next(enemies.Count);
                Debug.Log("Random enemy index: " + randomEnemyIndex);

            } while (currentEnemyIndex == randomEnemyIndex);



            Enemy enemyTarget = enemies[randomEnemyIndex];

            e.targetedByControlled = enemyTarget;

            int turn = 1;
            turn = Mathf.FloorToInt(turn * power);

            e.controlledTurns = turn;

            e.targetedByControlled = enemyTarget;
            Debug.Log(e.CName + " is now targeting " + enemyTarget.CName);
        }


        return true;

    }
}