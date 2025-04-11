using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class AllSkills : MonoBehaviour {
    [SerializeField] private TMP_Text pointCounterText;
    [SerializeField] private TMP_Text[] skillLevelTexts;
    [SerializeField] private GameObject[] skillNodes;

    public GameObject skillButtonPrefab;
    Player player;
    SkillTreeTree stt;

    public Skill[] allSkills;

    public void Init() {
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();

        SkillBook sb = new SkillBook();
        allSkills = sb.CreateSkillBook();

        // Initialize the skill tree with the skills
        stt = new SkillTreeTree(player);
        /*
        Debug.Log("Setting up skill tree...");
        stt.AddSkill(new Heal(), SkillTreeTree.SkillType.Defense);
        stt.AddSkill(new Sacrifice(), SkillTreeTree.SkillType.Defense);
        stt.AddSkill(new HeatWave(), SkillTreeTree.SkillType.Attack);
        SetNodes();
        */

        foreach (AllSkills skill : allSkills){
            stt.AddNode(skill, skillButtonPrefab);
        }
    }

    void Awake() {

        Init();

    }

    /*
        AllSkills is placed on Canvas. On each skill button, the onClick() can be bound to the Canvas, with the AllSkills method 
        SkillTreeClick, taking in the name of the skill (as described in the skill). This will send the skill to unlock/upgrade
        in the AbilityManager, taking in a skill and deciding what to do based on what is sent in.
    */

    public void SetNodes() {
        Debug.Log("Setting nodes...");
        SkillButtonNode current = stt.root;
        int index = 0;

        SetNodeRecursive(current, index);
        SetPointCounter();
    }

    void SetNodeRecursive(SkillButtonNode node, int index) {
        if (index < skillNodes.Length && node != null) {
        Debug.Log("index: " + index + ", skill: " + node.skill.Name);
            Image imageComponent = skillNodes[index].GetComponent<Image>();
            Text textComponent = skillNodes[index].GetComponent<Text>();
            TMP_Text skillLevelText = skillLevelTexts[index];


            Skill skill = node.skill;

            if (imageComponent != null) {
                if (skill.unlocked) {
                    imageComponent.color = Color.green;
                } else {
                    imageComponent.color = Color.gray;
                }
            }

            if (skillLevelText != null && skill.unlocked) {
                skillLevelText.text = skill.SkillLevel.ToString();
            }

            if (skillLevelText != null && !skill.unlocked) {
                skillLevelText.text = "Unlock";
            }

            if (textComponent != null){
                textComponent.text = skill.Name;
            }
            index++;
            SetNodeRecursive(node.left, index);
            index++;
            SetNodeRecursive(node.right, index);
        }
    }


    public void SkillTreeClick(int index) {
        Skill skill = allSkills[index];
        GetComponent<AbilityManager>().HandleSkill(skill);

        SetNodes();
        SetPointCounter();

        // SetPointCounter();
        // SetSkillLevelCounters();
        // SetSkillColors();
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
