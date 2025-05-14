using TMPro;     
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;               
    public TMP_Text valueText;         

    public void Init() {

        slider = GetComponent<Slider>();               
        valueText = GetComponentInChildren<TMP_Text>();
        
    }

    public void UpdateBar(int current, int max, int type)
    {
        if (slider == null || valueText == null || max == 0) return;

        current = Mathf.Clamp(current, 0, max); // To keep current between 0 and the max value

        float percentage = (float)current / max;
        slider.value = percentage;
        valueText.text = $"{current} / {max}";
        float colorValue = MapValue(current, 0f, max, 1.0f, 0f);
        valueText.color = new Color(colorValue, colorValue, colorValue, 1f);
        if (type == 0) {
            UpdateBarColor(percentage);
        }
    }

    private float MapValue(float value, float fromLow, float fromHigh, float toLow, float toHigh) {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }

    private void UpdateBarColor(float hpPercentage) {
        Image sliderFill = slider.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        if (hpPercentage >= 0.75f) {
            sliderFill.color = new Color32(0, 255, 0, 255);
        } else if (hpPercentage >= 0.50f) {
            sliderFill.color = new Color32(245, 236, 66, 255);
        } else if (hpPercentage >= 0.25f) {
            sliderFill.color = new Color32(245, 144, 66, 255);
        } else {
            sliderFill.color = new Color32(255, 43, 43, 255);
        }
    }
}
