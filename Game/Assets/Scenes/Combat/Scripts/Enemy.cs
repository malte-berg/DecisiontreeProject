using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public class Enemy : GameCharacter {

    Item[] availableItems;
    static readonly ConcurrentQueue<Action> _mainThreadActions = new ConcurrentQueue<Action>();

    public override void Init() {

        equipment = gameObject.GetComponent<Equipment>();
        GatherItems(20); // replace 20 with enemy power scaling
        skills[0] = new Punch(this);

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

            int mine = 0, available = 0;

            switch(availableItems.GetType()){

                case Type headType when headType == typeof(Head):
                    if(equipment.head != null)
                        mine = equipment.head.Value;
                    available = (availableItems[i] as Head).Value;
                    break;
                case Type torsoType when torsoType == typeof(Torso):
                    if(equipment.torso != null)
                        mine = equipment.torso.Value;
                    available = (availableItems[i] as Torso).Value;
                    break;
                case Type bootsType when bootsType == typeof(Boots):
                    if(equipment.boots != null)
                        mine = equipment.boots.Value;
                    available = (availableItems[i] as Boots).Value;
                    break;
                case Type weaponType when weaponType == typeof(Weapon):
                    if(equipment.weaponLeft != null)
                        mine = equipment.weaponLeft.Value;
                    available = (availableItems[i] as Weapon).Value;
                    break;
                case Type consumableType when consumableType == typeof(Consumable):
                    if(equipment.consumableLeft != null)
                        mine = equipment.consumableLeft.Value;
                    available = (availableItems[i] as Consumable).Value;
                    break;
                default:
                    break;

            }
            
            if(mine < available){
                if(purchasingPower / available < UnityEngine.Random.value)
                    equipment.Equip(availableItems[i]);
            }

        }

    }

}
