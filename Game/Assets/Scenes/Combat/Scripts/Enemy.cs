using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : GameCharacter {

    Item[] availableItems;
    int enemyPower;

    //For mindcontrol ability
    public Enemy targetedByControlled = null; // which target the mind controlled enemy targets
    public int controlledTurns = 0; // How many turns enemy is controlled when mindcontrol is activated.

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

        // TODO TEMP REMOVE
        availableItems = new Item[22];
        availableItems[0] = new Pipe();
        availableItems[1] = new Knife();
        availableItems[2] = new Katana();
        availableItems[3] = new Excalibur();
        availableItems[4] = new Broadsword();
        availableItems[5] = new BrassKnuckles();
        availableItems[6] = new MilitaryJacket();
        availableItems[7] = new Jacket();
        availableItems[8] = new CombatJacket();
        availableItems[9] = new Chainmail();
        availableItems[10] = new CombatHelmet();
        availableItems[11] = new ClimbingHelmet();
        availableItems[12] = new Bucket();
        availableItems[13] = new BicycleHelmet();
        availableItems[14] = new WorkerBoots();
        availableItems[15] = new SteelToedBoots();
        availableItems[16] = new HikingBoots();
        availableItems[17] = new GladiatorHelmet();
        availableItems[18] = new EnforcerHelmet();
        availableItems[19] = new MageHat();
        availableItems[20] = new Wand();
        availableItems[21] = new Staff();


        this.availableItems = availableItems;
        level += (int)(7 * rnd) - 3;
        if(level < 1) level = 1;
        CName = cName;
        
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

        if (targetedByControlled != null){
            target = targetedByControlled;
            controlledTurns--;
            targetedByControlled = MindControl.GetRandomEnemy(this, this.c.Enemies);
        }

        if (controlledTurns <= 0){
            controlledTurns = 0; //just to be sure
            targetedByControlled = null;
        }

        int currentS = 2;
        while(!SelectSkill(currentS-- % 3));

        // run on main thread (needed for component access)
        _mainThreadActions.Enqueue(() => {
            c.UseTurnOn(target);
        });

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
                    if(CanBeWorn(i, thresh))
                        equipment.Equip(availableItems[i]);

            }

        }

    }

    // come constrains on certaint enemies
    // also randomises so each allowed equipment has a 2/3 chance to be equipped
    bool CanBeWorn(int i, double thresh) {
        int rand = (int)(thresh * 11337);
        bool acceptWeapon = true;
        bool acceptHat = true;
        bool acceptTorso = true;
        bool acceptAnyHat = false;
        if((rand % 2) == 1)
            acceptHat = false;
        // if((rand % 3) == 2)
        //     acceptWeapon = false; // always have a weapon?
        if((rand % 3) == 1)
            acceptTorso = false;
        if((rand % 7) == 6)
            acceptAnyHat = true;

        string enemyName = this.gameObject.name;
        Item item = availableItems[i];
        
        if(item is Torso) {
            if(!(enemyName.Contains("Thug") || enemyName.Contains("Addict")))
                return false;
            else return acceptTorso;
        }
        else if(item is Weapon) {
            if(enemyName.Contains("Mage")) {
                if((item is Staff || item is Wand)) {
                    return acceptWeapon;
                }else {
                    return false;
                }
            }

            else return acceptWeapon;
        }
        else if(item is Head) {
            if(enemyName.Contains("Leader")) {
                return false;
            }
            else if(acceptAnyHat) {
                return true;
            }
            else if(enemyName.Contains("Gladiator")) {
                if(item is GladiatorHelmet) return acceptTorso;
                else return false;
            }
            else if(enemyName.Contains("Mage")) {
                if(item is MageHat) return acceptTorso;
                else return false;
            }
            else if(enemyName.Contains("Guard")){
                if(item is EnforcerHelmet)
                    return acceptTorso;
            }
            else {
                return acceptHat;
            }
        }
        return true;
    }

    void GatherSkills(int skillPower){

        SkillBook sb = new SkillBook();
        skillPower = Math.Clamp(skillPower, 0, sb.Count-1);

        while(skillPower > 0){

            Skill potential = sb.ReadPage(skillPower);
            potential.UnlockSkill(this);

            skillPower--;

        }

    }

}
