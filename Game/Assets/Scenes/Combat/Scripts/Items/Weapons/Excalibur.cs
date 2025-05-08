public class Excalibur : Weapon{

    public Excalibur() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/excalibur_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/excalibur1"), Resources.Load<Sprite>("Sprites/Items/excalibur2")},
        name: "Excalibur",
        value: 28000,
        description: "Created with unknown forging, created presumably by the gods of this world, no one can wield it, no one can withstand it, no one shall remember its existence.",
        vitalityAdd: 2400,
        vitalityMult: 25.6f,
        armorAdd: 1120,
        armorMult: 10.4f,
        strengthAdd: 9600,
        strengthMult: 105.2f,
        magicAdd: 8700,
        magicMult: 99.7f,
        manaAdd: 650,
        manaMult: 22.3f
        
    ) {
        
    }

}