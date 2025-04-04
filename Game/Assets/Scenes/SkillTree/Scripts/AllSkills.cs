using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class AllSkills : MonoBehaviour {
    [SerializeField] private TMP_Text pointCounterText;
    [SerializeField] private TMP_Text[] skillLevelTexts;
    [SerializeField] private GameObject[] skillNodes;
    Player player;

    public Skill[] allSkills;

    public void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();

        allSkills = new Skill[16];
        allSkills[0] = new Punch(player);
        allSkills[1] = new HeatWave(player);
        allSkills[2] = new Heal(player);
        allSkills[3] = new Sacrifice(player);

        SetSkillLevelCounters();
        SetSkillColors();
        SetPointCounter();
    }

    void Awake()
    {

        Init();

    }

    public void SkillTreeClick(int index) {
        if (index < 0 || index >= allSkills.Length) {
            Debug.Log("Invalid skill index");
            return;
        }

        Debug.Log($"Clicked on skill: {allSkills[index].name}");
        Skill skill = allSkills[index];
        if (GetComponent<AbilityManager>().HandleSkill(skill)) {
            SetPointCounter();
        }
        SetSkillLevelCounters();
        SetSkillColors();
    }

    public void SetSkillLevelCounters() {
        for (int i = 0; i < skillLevelTexts.Length; i++) {
            if (allSkills[i] == null) {
                continue;
            }
            TMP_Text skillLevelText = skillLevelTexts[i];
            if (skillLevelText != null && allSkills[i].unlocked) {
                skillLevelText.text = allSkills[i].level.ToString();
            }
            if (skillLevelText != null && !allSkills[i].unlocked) {
                skillLevelText.text = "Unlock";
            }
        }
    }

    public void SetSkillColors() {
        for (int i = 0; i < skillNodes.Length; i++) {
            if (allSkills[i] == null) {
                continue;
            }
            GameObject skillNode = skillNodes[i];
            Image imageComponent = skillNode.GetComponent<Image>();
            if (imageComponent != null) {
                if (allSkills[i].unlocked) {
                    imageComponent.color = Color.green;
                } else {
                    imageComponent.color = Color.gray;
                }
            }
        }
    }

    public void SetPointCounter() {
        int points = player.SkillPoints;
        try
        {
            pointCounterText.text = points.ToString();
            
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error setting point counter: " + e.Message);
        }
        
    }
}
