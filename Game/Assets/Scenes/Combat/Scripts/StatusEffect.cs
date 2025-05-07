public class StatusEffect{

    int turns;
    public int Turns{ get{ return turns;} set{ turns = value;}}
    int delta;
    public int Delta{ get{ return delta; } set{ delta = value; }}
    float deltaF;
    public float DeltaF{ get{ return deltaF; } set{ deltaF = value; }}
    int effectType;
    public int EffectType{ get{ return effectType; } set{ effectType = value; }}

    /*
    0 - Vitality modifier
    1 - Armor modifier
    2 - Strength modifier
    3 - Magic modifier
    4 - Mana modifier
    5 - Stun
    */

    public StatusEffect(int turns, int delta, float deltaF, int effectType){

        this.turns = turns;
        this.delta = delta;
        this.deltaF = deltaF;
        this.effectType = effectType;

    }

    public void DecrementEffect(){

        turns--;

    }

}