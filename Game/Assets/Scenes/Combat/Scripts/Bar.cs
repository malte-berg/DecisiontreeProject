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
        UpdateTextColor(percentage);
        if (type == 0) {
            UpdateBarColor(percentage);
        }
    }

    private void UpdateTextColor(float hpPercentage) {
        valueText.color = ColorFromPercentage(hpPercentage, true);
    }

    private void UpdateBarColor(float hpPercentage) {
        Image sliderFill = slider.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        sliderFill.color = ColorFromPercentage(hpPercentage, false);
    }

    private Color32 ColorFromPercentage(float value, bool isText) {
        if (value >= 0.75f) {
            if (isText) return new Color32(255, 255, 255, 255);
            return new Color32(52, 194, 0, 255);
        } else if (value >= 0.50f) {
            if (isText) return new Color32(255, 255, 255, 255);
            return new Color32(255, 203, 15, 255);
        } else if (value >= 0.25f) {
            return new Color32(245, 144, 66, 255);
        } else {
            return new Color32(255, 43, 43, 255);
        }
    }
}
