using System;
using UnityEngine;

[Serializable]
public class Save{
    
    // Save specific
    public static int latestVersion = 8;
    [SerializeField] public string created;
    [SerializeField] public int version;
    [SerializeField] public long seed;

    // Experience
    [SerializeField] public int level;
    [SerializeField] public int xp;

    // Resources
    [SerializeField] public int gold;
    [SerializeField] public int skillPoints;
    
    // Progression
    [SerializeField] public int area;
    [SerializeField] public int[] combats;

    // Stats
    [SerializeField] public int statPoints;
    [SerializeField] public int[] stats;

    // Items
    [SerializeField] public int[] equipped;
    [SerializeField] public string[] inventory;

    // Skills
    [SerializeField] public int[] levels;
    [SerializeField] public int[] selected;
    [SerializeField] public string[] skills;

    public Save(long seed, int level, int xp, int gold, int skillPoints, int area, int[] combats, int statPoints, int[] stats, int[] equipped, string[] inventory, int[] levels, int[] selected, string[] skills){

        created = DateTime.Now.ToString("O");
        version = latestVersion;
        this.seed = seed;

        // No seed => randomize seed
        if(seed == 0){
            System.Random random = new System.Random();
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            this.seed = BitConverter.ToInt64(buffer, 0);
        }

        this.level = level;
        this.xp = xp;
        this.gold = gold;
        this.skillPoints = skillPoints;
        this.area = area;
        this.combats = combats;
        this.statPoints = statPoints;
        this.stats = stats;
        this.equipped = equipped;
        this.inventory = inventory;
        this.levels = levels;
        this.selected = selected;
        this.skills = skills;
    
    }

}