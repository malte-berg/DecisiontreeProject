using UnityEngine;

public class ManaBar : Bar
{
    public GameCharacter targetCharacter;

    public void Start()
    {
        if (targetCharacter != null)
           target = targetCharacter.transform;

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
        if (targetCharacter == null) return;

        UpdateBar(targetCharacter.Mana, targetCharacter.MaxMana);
    }
}

