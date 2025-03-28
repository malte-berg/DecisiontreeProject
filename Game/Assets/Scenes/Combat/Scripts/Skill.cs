using UnityEngine;

public abstract class Skill{

    GameCharacter gc;
    int manaCost;

    public Skill(GameCharacter gc, int manaCost){

        this.gc = gc;
        this.manaCost = manaCost;

    }

    public abstract bool Effect(GameCharacter target);

}
