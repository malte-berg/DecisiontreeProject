using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : GameCharacter {

    public override void Init() {

        equipment = gameObject.GetComponent<Equipment>();
        skills[0] = new Punch(this);

        this.SetSprite("Enemy");
        
    }

    public async Task AI(Combat c, GameCharacter target){

        // Thread.Sleep(1000);
        new Task(() => {c.CharacterClicked(target);}).Start();

    }

}
