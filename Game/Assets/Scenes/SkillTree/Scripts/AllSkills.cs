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

    public void Init() {
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();

        SkillBook sb = new SkillBook();
        sb.Load();
        allSkills = sb.Pages;

        SetSkillLevelCounters();
        SetSkillColors();
        SetPointCounter();
    }

    void Awake() {

        Init();

    }

    /*
        AllSkills is placed on Canvas. On each skill button, the onClick() can be bound to the Canvas, with the AllSkills method 
        SkillTreeClick, taking in the name of the skill (as described in the skill). This will send the skill to unlock/upgrade
        in the AbilityManager, taking in a skill and deciding what to do based on what is sent in.
    */
    public void SkillTreeClick(int index) {
        Skill skill = allSkills[index];
        GetComponent<AbilityManager>().HandleSkill(skill);

        SetPointCounter();
        SetSkillLevelCounters();
        SetSkillColors();
    }

    public void SetSkillLevelCounters() {
        for (int i = 0; i < skillLevelTexts.Length; i++) {
            if (allSkills[i] == null) {
                continue;
            }
            TMP_Text skillLevelText = skillLevelTexts[i];

            Skill playerSkill = GetComponent<AbilityManager>().GetPlayerSkillByName(allSkills[i].Name);
            if (playerSkill != null) {
                allSkills[i] = playerSkill;
            }
            if (skillLevelText != null && allSkills[i].unlocked) {
                skillLevelText.text = allSkills[i].SkillLevel.ToString();
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

            Skill playerSkill = GetComponent<AbilityManager>().GetPlayerSkillByName(allSkills[i].Name);
            if (playerSkill != null) {
                allSkills[i] = playerSkill;
            }

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
