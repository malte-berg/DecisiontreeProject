using UnityEngine;
using UnityEngine.UI;

public class SkillSelection : MonoBehaviour
{
    public Image selectBorder;
    public Button[] skillButtons = new Button[8]; // Array for 8 skill buttons

    private RectTransform[] buttonTransforms = new RectTransform[8];
    private Player player;

    private RectTransform imageRect;

    void Start()
    {
        SelectBordInit();

        player = GameObject.Find("Player").GetComponent<Player>();

        for (int i = 0; i < skillButtons.Length; i++)
        {
            int skillIndex = i; // Capture index for lambda
            buttonTransforms[i] = skillButtons[i].GetComponent<RectTransform>();
            skillButtons[i].onClick.AddListener(() => SelectSkill(skillIndex));
        }

        UpdateSkillButtons();
    }

    void SelectBordInit()
    {
        imageRect = selectBorder.GetComponent<RectTransform>();
        NotShowSelect();
    }
    public void UpdateSkillButtons()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].interactable = player.skills.Length > i && player.skills[i] != null;
        }
    }

    public void SelectSkill(int skillIndex)
    {
        if (player.skills == null || player.skills.Length <= skillIndex || player.skills[skillIndex] == null)
        {
            Debug.LogWarning($"Skill selection failed: Index {skillIndex} is out of bounds or skill is null.");
            return;
        }
        ShowSelect();
        imageRect.anchoredPosition = buttonTransforms[skillIndex].anchoredPosition;;
        //player.SetSelectedSkill(skillIndex);  //ADD THE FUNCTION ALREADY IN GAMECHARACTER
        Debug.Log($"Selected skill: {player.skills[skillIndex]?.Name}");
    }

    void ShowSelect()
    {
        selectBorder.enabled = true;
    }

    void NotShowSelect()
    {
        selectBorder.enabled = false;
    }
}