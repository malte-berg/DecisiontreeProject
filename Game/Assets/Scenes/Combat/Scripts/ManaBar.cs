using UnityEngine;

public class ManaBar : Bar
{
    // public Slider manaSlider;
    public GameCharacter targetCharacter;
    // public TMP_Text mpText;
    // int currentMana;
    // int maxMana;

    public void Start()
    {
        base.Init(); // Check for target
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
        /*if (manaSlider == null || targetCharacter == null)
            return;

        currentMana = targetCharacter.Mana;
        maxMana = targetCharacter.MaxMana;

        float mpBarPercentage = (float)currentMana / maxMana;
        manaSlider.value = mpBarPercentage;
        mpText.text = $"{currentMana} / {maxMana}";

        manaSlider.maxValue = maxMana;
        manaSlider.value = currentMana;*/

        if (targetCharacter == null) return;

        UpdateBar(targetCharacter.Mana, targetCharacter.MaxMana);
    }
}

