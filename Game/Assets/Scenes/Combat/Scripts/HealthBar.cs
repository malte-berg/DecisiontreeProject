using UnityEngine;

public class HealthBar : Bar {

    // Slider slider;
    // TMP_Text hpText;

    public override void Init(){

        // slider = GetComponent<Slider>();
        // hpText = GetComponentInChildren<TMP_Text>();
        base.Init();
    }

    public void UpdateHealthBar(int currentHP, int maxHP){

        /*if (slider == null || hpText == null) return;

        float hpBarPercentage = (float)currentHP/maxHP;
        slider.value = hpBarPercentage;
        hpText.text = $"{currentHP} / {maxHP}";*/

        UpdateBar(currentHP, maxHP);

    }
}
