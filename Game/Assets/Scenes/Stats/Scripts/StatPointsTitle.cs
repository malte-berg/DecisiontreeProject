using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatPointsTitle : MonoBehaviour {
    
    [SerializeField]
    public GameObject statPointsText;
    public Slider statSlider;
    public int sliderValue;
    public int statPoints = 150;
    
    void Update() {
        sliderValue = (int) statSlider.value;
        statPointsText.GetComponent<TextMeshProUGUI>().text = "Stat points: " + (statPoints - sliderValue);
    }
}
