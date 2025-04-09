using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public class Enemy : GameCharacter {

    Item[] availableItems;
    static readonly ConcurrentQueue<Action> _mainThreadActions = new ConcurrentQueue<Action>();

    public override void Init() {

        equipment = gameObject.GetComponent<Equipment>();
        skills[0] = new Punch(this);

        // temp
        availableItems = new Item[17];
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
        GatherItems(40); // replace 20 with enemy power scaling

        SetSprite("Enemy");
        
    }

    void FixedUpdate(){ // kinda unnecessary updates

        while(_mainThreadActions.TryDequeue(out var action))
            action?.Invoke();
        
    }

    public async Task AI(Combat c, GameCharacter target){

        Thread.Sleep(1000);

        int currentS = 2;
        while(!SelectSkill(currentS-- % 3));

        // run on main thread (needed for component access)
        _mainThreadActions.Enqueue(() => {
            c.UseTurnOn(target);
        });

    }

    void GatherItems(int purchasingPower){

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
                float thresh = UnityEngine.Random.value;

                if(rnd > thresh)
                    equipment.Equip(availableItems[i]);

            }

        }

    }

}
