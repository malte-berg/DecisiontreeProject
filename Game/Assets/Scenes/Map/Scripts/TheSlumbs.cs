public class TheSlumbs : Area {
    
    public Item[] regionItems;

    public override void Init(){

        regionItems = new Item[]{
            new Knife(),
            new Pipe(),
            new BrassKnuckles(),
            new Jacket(),
            new CombatJacket(),
            new Bucket(),
            new BicycleHelmet(),
            new WorkerBoots()
        };

    }

    public override Item[] GetItems(){

        return regionItems;

    }

}