using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar {

    Slider slider;
    TMP_Text hpText;

    public void Init(){

        slider = GetComponent<Slider>();
        hpText = GetComponentInChildren<TMP_Text>();

    }

    public void UpdateHealthBar(int currentHP, int maxHP){

        if (slider == null || hpText == null) return;

        float hpBarPercentage = (float)currentHP/maxHP;
        slider.value = hpBarPercentage;
        hpText.text = $"{currentHP} / {maxHP}";

    }
}
