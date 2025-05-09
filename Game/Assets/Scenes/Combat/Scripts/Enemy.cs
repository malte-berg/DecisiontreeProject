using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : GameCharacter {

    Item[] availableItems;
    public int level;
    static readonly ConcurrentQueue<Action> _mainThreadActions = new ConcurrentQueue<Action>();

    public Enemy() : base(

        cName: "N/A",
        vitality: 100,
        armor: 0,
        strength: 10,
        magic: 0,
        mana: 0,
        maxSkill: 8,
        inventorySize: 2

    ){}

    public void CreateEnemy(Item[] availableItems, double rnd, string cName){

        StartCoroutine(FixBars());

        if(sprites[0] == null) {
            sprites = new List<Sprite> {Resources.Load<Sprite>("Sprites/Characters/enemyTemp1"), Resources.Load<Sprite>("Sprites/Characters/enemyTemp2")};
        }

        this.availableItems = availableItems;
        level += (int)(7 * rnd) - 3;
        if(level < 1) level = 1;
        CName = cName;

        // have stats based on level
        Vitality = (int)(MathF.Log(level, MathF.E) + 1) * (int)(80 + 40 * rnd);
        Armor = (int)(MathF.Log(level, MathF.E) + 1) * (int)(1 + 3 * rnd);
        Strength = (int)(MathF.Log(level, MathF.E) + 1) * (int)(8 + 8 * rnd);
        Magic = (int)(MathF.Log(level, MathF.E) + 1) * (int)(2 + 14 * rnd);
        MaxMana = (int)(MathF.Log(level, MathF.E) + 1) * (int)(5 + 11 * rnd);
        HP = Vitality;
        Mana = MaxMana;

        Punch punch = new Punch();
        punch.UnlockSkill(this);
        AddSkill(punch);
        
        GatherItems((level - 1) * 10 + 1, rnd);
        GatherSkills(level / 3);
        equipment.PrintEquipment();

        SetSprite();

    }

    void FixedUpdate(){ // kinda unnecessary updates

        while(_mainThreadActions.TryDequeue(out var action))
            action?.Invoke();
        
    }

    public async Task AI(Combat c, GameCharacter target){

        Thread.Sleep(1000);

        // run on main thread (needed for component access)
        _mainThreadActions.Enqueue(() => {
            AttemptSkill(target);
        });

    }

    void AttemptSkill(GameCharacter target){

        bool success;
        bool self = false;
        int currentS = 3;

        do{

            if(!self)
                while(!SelectSkill(--currentS % 3));

            if(c == null) return;

            success = c.UseTurnOn(self ? this : target);
            self = !self;
        
        } while(!success);

    }

    void GatherItems(int purchasingPower, double thresh){

        for(int i = 0; i < availableItems.Length; i++){

            int mine = 0, available = availableItems[i].Value;

            switch(availableItems[i]){

                case Head:
                    if(equipment.head != null)
                        mine = equipment.head.Value;
                    break;
                case Torso:
                    if(equipment.torso != null)
                        mine = equipment.torso.Value;
                    break;
                case Boots:
                    if(equipment.boots != null)
                        mine = equipment.boots.Value;
                    break;
                case Weapon:
                    if(equipment.weaponLeft != null)
                        mine = equipment.weaponLeft.Value;
                    break;
                case Consumable:
                    if(equipment.consumableLeft != null)
                        mine = equipment.consumableLeft.Value;
                    break;
                default:
                    break;

            }

            if(mine < available){
                float rnd = (float)purchasingPower / available;

                if(rnd > thresh)
                    if(CanBeWorn(i))
                        equipment.Equip(availableItems[i]);

            }

        }

    }

    // will expand on this later
    bool CanBeWorn(int i) {
        string enemyName = this.gameObject.name;
        Item item = availableItems[i];
        
        if(!(enemyName.Contains("Thug"))) {
            if(item is Torso) return false;
        }
        if(enemyName.Contains("Mage")) {
            if(item is Weapon) return false;
            else if(item is Head && !(item is MageHat)) return false;
        }
        else if(enemyName.Contains("Gladiator")) {
            if(item is Head && !(item is GladiatorHelmet)) return false;
        }
        else if(enemyName.Contains("Leader")) {
            if(item is Head) return false;
        }
        return true;
    }

    void GatherSkills(int skillPower){

        SkillBook sb = new SkillBook();
        skillPower = Math.Clamp(skillPower, 0, sb.Count-1);

        while(skillPower > 0){

            Skill potential = sb.ReadPage(skillPower);
            skillPower--;
            if(potential is Sacrifice) continue; // ignoring sacrifice to limit amount of self use abilities
            potential.UnlockSkill(this);
            AddSkill(potential);

        }

    }

}
