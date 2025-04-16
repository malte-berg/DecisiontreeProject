using System;
using UnityEngine;

[Serializable]
public class Save{
    
    // Experience
    [SerializeField] int level;
    [SerializeField] int xp;

    // Resources
    [SerializeField] int gold;
    [SerializeField] int skillPoints;
    
    // Progression
    [SerializeField] int area;
    [SerializeField] int[] combats;

    // Items
    [SerializeField] int[] equipped;
    [SerializeField] Type[] inventory;

    // Skills
    [SerializeField] int[] levels;
    [SerializeField] Type[] skills;

    public Save(int level, int xp, int gold, int skillPoints, int area, int[] combats, int[] equipped, Type[] inventory, int[] levels, Type[] skills){

        this.level = level;
        this.xp = xp;
        this.gold = gold;
        this.skillPoints = skillPoints;
        this.area = area;
        this.combats = combats;
        this.equipped = equipped;
        this.inventory = inventory;
        this.levels = levels;
        this.skills = skills;
    
    }

}