using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Slider slider;
    TMP_Text hpText;

    public void Init(){

        slider = GetComponent<Slider>();
        hpText = GetComponent<TMP_Text>();

    }

    public void UpdateHealthBar(int currentHP, int maxHP){

        float hpBarPercentage = (float)currentHP/maxHP;
        slider.value = hpBarPercentage;
        hpText.text = $"{currentHP} / {maxHP}";

    }
}
