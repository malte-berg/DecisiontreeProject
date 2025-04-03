using UnityEngine;

public class Enemy : GameCharacter
{
    public override void Init() {

        equipment = gameObject.GetComponent<Equipment>();
        skills[0] = new Punch(this);

        this.SetSprite("Enemy");
    }
}
