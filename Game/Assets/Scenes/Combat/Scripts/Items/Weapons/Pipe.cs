using System.Collections.Generic;
using UnityEngine;

public class Pipe : Weapon{

    public Pipe() : base(

        icon: Resources.Load<Sprite>("Sprites/Icons/pipe_Icon"),
        sprites: new List<Sprite> {Resources.Load<Sprite>("Sprites/Items/pipe1"), Resources.Load<Sprite>("Sprites/Items/pipe2")},
        name: "Pipe",
        value: 5,
        description: "A random pipe that no one knows the origin of.",
        vitalityAdd: 0,
        vitalityMult: 1,
        armorAdd: 0,
        armorMult: 1,
        strengthAdd: 1,
        strengthMult: 1.001f,
        magicAdd: 0,
        magicMult: 1,
        manaAdd: 0,
        manaMult: 1

    ) {
        
    }

}