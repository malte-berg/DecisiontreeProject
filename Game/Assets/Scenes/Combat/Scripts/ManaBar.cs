using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;
    public GameCharacter targetCharacter;
    public TMP_Text mpText;
    int currentMana;
    int maxMana;

    void Start()
    {
        if (targetCharacter == null)
        {
            Debug.LogError("ManaBar: No target character assigned.");
            enabled = false;
            return;
        }

        mpText = GetComponentInChildren<TMP_Text>();
        UpdateManaBar();
    }

    void Update()
    {
        if (targetCharacter != null)
        {
            UpdateManaBar();
        }
    }

    public void UpdateManaBar()
    {
        if (manaSlider == null || targetCharacter == null)
            return;

        currentMana = targetCharacter.Mana;
        maxMana = targetCharacter.MaxMana;

        float mpBarPercentage = (float)currentMana / maxMana;
        manaSlider.value = mpBarPercentage;
        mpText.text = $"{currentMana} / {maxMana}";

        manaSlider.maxValue = maxMana;
        manaSlider.value = currentMana;
    }
}

