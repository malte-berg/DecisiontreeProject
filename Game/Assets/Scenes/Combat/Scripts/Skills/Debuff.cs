using UnityEngine;
using System.Collections.Generic;

public class Debuff
{
    public int amount;

    public Debuff(int amount)
    {
        this.amount = amount;
    }

    public static void DebuffStat(GameCharacter debuffedCharacter, string stat, int reduction)
    {
        var debuffStatAmounts = debuffedCharacter.effects; //Dictionary containing the amount each stat will be reduced by

        if (debuffStatAmounts.ContainsKey(stat))
        {
            debuffStatAmounts[stat].amount += reduction;
        }
        else
        {
            debuffStatAmounts[stat] = new Debuff(reduction);
        }
    }
}



