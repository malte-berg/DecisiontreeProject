using System;
using UnityEngine;

[Serializable]
public class Save{
    
    // Save specific
    [SerializeField] string created;
    [SerializeField] int version;
    [SerializeField] long seed;

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
    [SerializeField] string[] inventory;

    // Skills
    [SerializeField] int[] levels;
    [SerializeField] int[] selected;
    [SerializeField] string[] skills;

    public Save(int level, int xp, int gold, int skillPoints, int area, int[] combats, int[] equipped, string[] inventory, int[] levels, int[] selected, string[] skills){

        created = DateTime.Now.ToString("O");
        version = 3;
        System.Random random = new System.Random();
        byte[] buffer = new byte[8];
        random.NextBytes(buffer);
        seed = BitConverter.ToInt64(buffer, 0);
        this.level = level;
        this.xp = xp;
        this.gold = gold;
        this.skillPoints = skillPoints;
        this.area = area;
        this.combats = combats;
        this.equipped = equipped;
        this.inventory = inventory;
        this.levels = levels;
        this.selected = selected;
        this.skills = skills;
    
    }

}