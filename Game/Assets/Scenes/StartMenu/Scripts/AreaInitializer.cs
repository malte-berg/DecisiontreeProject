using UnityEngine;
using System.Collections.Generic;
public class AreaInitializer : MonoBehaviour
{
    // private Item[][] religionItems;
    public Dictionary<int, Item[]> religionItems = new Dictionary<int, Item[]>();

    public void Init()
    {
        ReligionItemsInit();
        // AreaDictionaryInit();       
    }

    void ReligionItemsInit(){
        // religionItems[0] = new Item[] {}; // tutorial area
        religionItems[1] = new Item[] {
            new Knife(),
            new Pipe(),
            new BrassKnuckles(),
            new Jacket(),
            new CombatJacket(),
            new Bucket(),
            new BicycleHelmet(),
            new WorkerBoots()
         };
        // currently it is just a test, specific items need to be conceived
        religionItems[2] = new Item[] {
            new Excalibur(),
            new BicycleHelmet(),
            new Chainmail(),
            new Katana()
        };
        religionItems[3] = new Item[] { 
            new MilitaryJacket(),
            new Katana(),
            new Chainmail()
        };

        AreaDataLoader.InitAreaRegionItems(1, religionItems[1]);
        AreaDataLoader.InitAreaRegionItems(2, religionItems[2]);
        AreaDataLoader.InitAreaRegionItems(3, religionItems[3]);
    }

    void AreaDictionaryInit()
    {
        Debug.Log("religionItems.Count"+religionItems.Count);
        for (int i = 1; i < religionItems.Count; i++)
        {
            AreaDataLoader.InitAreaRegionItems(i, GetAreaItems(i));
        }
    }

    public Item[] GetAreaItems(int key)
    {
        if (religionItems.TryGetValue(key, out var array))
            return array;

        return null;
    }

}
