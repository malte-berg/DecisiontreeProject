public class StatusEffect{

    int turns;
    public int Turns{ get{ return turns; }}
    int delta;
    public int Delta{ get{ return delta; }}
    float deltaF;
    public float DeltaF{ get{ return deltaF; }}
    int effectType;
    public int EffectType{ get{ return effectType; }}

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