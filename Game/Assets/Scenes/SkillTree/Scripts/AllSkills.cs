using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class AllSkills : MonoBehaviour {
    public TMP_Text pointCounterText;

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
        
        int offsetX = 200;
        foreach (Skill skill in allSkills){
            if (skill == null) {
                continue;
            }

            Debug.Log(skill.Name);

            Vector3 position = new Vector3(offsetX, 200, 0);
            GameObject skillButton = Instantiate(skillButtonPrefab, position, Quaternion.identity, transform);
            SkillButtonNode node = skillButton.GetComponent<SkillButtonNode>();
            node.Init(skillButton, player, skill, null, pointCounterText);

            stt.AddNode(node);
            offsetX += 150;
        }
    }

    void Awake() {

        Init();

    }
}
