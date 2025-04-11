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

    public void UpdateBar(int current, int max)
    {
        if (slider == null || valueText == null || max == 0) return;

        current = Mathf.Clamp(current, 0, max); // To keep current between 0 and the max value

        float percentage = (float)current / max;
        slider.value = percentage;
        valueText.text = $"{current} / {max}";
    }
}
