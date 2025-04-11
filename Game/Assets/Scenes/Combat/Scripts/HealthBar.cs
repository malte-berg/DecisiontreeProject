using UnityEngine;

public class HealthBar : Bar {
    public override void Init(){
        base.Init();
    }

    public void UpdateHealthBar(int currentHP, int maxHP){
        UpdateBar(currentHP, maxHP);

    }
}