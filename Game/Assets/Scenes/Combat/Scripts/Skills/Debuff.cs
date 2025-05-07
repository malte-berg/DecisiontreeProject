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
        int statValue = GetStatValue(debuffedCharacter, stat);

        Debug.Log("Original reduction: " + reduction);
        Debug.Log("Stat value: " + statValue);

        if (reduction < 0)
        {
            if (statValue <= 0)
            {
                reduction = 0;
            }
            else if (Mathf.Abs(reduction) > statValue)
            {
                reduction = -statValue;
            }
        }

        Debug.Log("Final reduction to apply: " + reduction);

        var debuffStatAmounts = debuffedCharacter.effects;

        if (debuffStatAmounts.ContainsKey(stat))
        {
            debuffStatAmounts[stat].amount += reduction;
        }
        else
        {
            debuffStatAmounts[stat] = new Debuff(reduction);
        }
    }


    private static int GetStatValue(GameCharacter character, string stat)
    {
        switch (stat.ToLower())
        {
            case "armor": return character.Armor;
            case "mana": return character.Mana;
            case "magic": return character.Magic;
            case "vitality": return character.Vitality;
            case "hp": return character.HP;
            case "strength": return character.Strength;
            default:
                Debug.LogWarning("not a stat: " + stat);
                return 0;
        }
    }

}



