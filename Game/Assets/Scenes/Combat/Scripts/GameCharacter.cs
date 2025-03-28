using System.Threading.Tasks;
using UnityEngine;

public class GameCharacter : MonoBehaviour{

    Combat c;
    int HP = 100;
    int dmg = 15;
    int mana = 100;
    public Skill[] skills = new Skill[8];
    int skillCount = 1;
    int selectedSkill = 0;

    public int DMG{get{ return dmg; }}
    public int Mana{get{ return mana; } set{ this.mana = value; }}

    public void Init(Combat c){

        this.c = c;
        skills[0] = new Punch(this, 20);

    }

    void OnMouseDown(){

        c.CharacterClicked(this);

    }

    /// <summary>
    /// True means that the skill can be used
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns> <summary>
    public bool UseSkill(GameCharacter target){

        Skill usingSkill = skills[selectedSkill];

        if(!usingSkill.Effect(target))
            return false;

        return true;

    }

    public void TakeDamage(int dmg){

        // do some red effect
        HP -= dmg;
        DamageEffect();

        if(HP <= 0)
            c.KillCharacter(this);

    }

    async Task DamageEffect(){

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        float time = 0.5f;
        
        while(time > 0){

            sr.color = new Color(1,1-time,1-time);
            time -= Time.deltaTime;
            await Task.Yield();

        }
            
        sr.color = new Color(1,1,1);

    }

}