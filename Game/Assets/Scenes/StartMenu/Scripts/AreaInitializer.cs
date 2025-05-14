using UnityEngine;
using System.Collections.Generic;
public class AreaInitializer : MonoBehaviour
{
    // private Item[][] religionItems;
    public Dictionary<int, Item[]> religionItems = new Dictionary<int, Item[]>();

    public void Init()
    {
        ReligionItemsInit();
        AreaDictionaryInit();       
    }

    void ReligionItemsInit(){
        religionItems[0] = new Item[] {}; // tutorial area
        religionItems[1] = new Item[] {
            new Knife(),
            new Pipe(),
            new BrassKnuckles(),
            new Jacket(),
            new CombatJacket(),
            new Bucket(),
            new BicycleHelmet(),
            new WorkerBoots(),
            new Wand()
         };
        // currently it is just a test, specific items need to be conceived
        religionItems[2] = new Item[] {
            new SteelToedBoots(),
            new ClimbingHelmet(),
            new Chainmail(),
            new BrassKnuckles(),
            new Broadsword(),
            new EnforcerHelmet(),
            new MageHat(),
            new Staff()
        };
        religionItems[3] = new Item[] { 
            new MilitaryJacket(),
            new Katana(),
            new SteelToedBoots(),
            new CombatHelmet(),
            new Excalibur(),
            new GladiatorHelmet(),
        };

        /* AreaDataLoader.InitAreaRegionItems(1, religionItems[1]);
        AreaDataLoader.InitAreaRegionItems(2, religionItems[2]);
        AreaDataLoader.InitAreaRegionItems(3, religionItems[3]); */
    }

    void AreaDictionaryInit()
    {
        for (int i = 1; i < religionItems.Count; i++)
        {
            AreaDataLoader.InitAreaRegionItems(i, GetAreaItems(i));
        }
    }

    Item[] GetAreaItems(int key)
    {
        if (religionItems.TryGetValue(key, out var array))
            return array;

        return null;
    }

}
