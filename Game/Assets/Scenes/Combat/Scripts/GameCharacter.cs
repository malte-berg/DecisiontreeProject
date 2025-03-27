using UnityEngine;

public class GameCharacter : MonoBehaviour{

    Combat c;
    int HP = 100;
    int dmg = 15;

    public void Init(Combat c){

        this.c = c;

    }

    void OnMouseDown(){

        c.CharacterClicked(this);

    }

    public void Attack(GameCharacter target){

        print(name + " attacks: " + target.gameObject.name);
        target.TakeDamage(dmg);

    }

    public void TakeDamage(int dmg){

        HP -= dmg;

        if(HP <= 0)
            Destroy(gameObject);

    }

}
