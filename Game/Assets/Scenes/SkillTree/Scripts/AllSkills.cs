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

        GameObject skillButton = Instantiate(skillButtonPrefab, transform);
        SkillButtonNode punch = skillButton.GetComponent<SkillButtonNode>();
        punch.Init(skillButton, player, player.skills[0], null, pointCounterText);
        punch.offsetX = 0;
        punch.offsetY = -200;
        punch.MoveNode();

        stt.AddNode(punch);

        skillButton = Instantiate(skillButtonPrefab, transform);
        SkillButtonNode heatWave = skillButton.GetComponent<SkillButtonNode>();
        heatWave.Init(skillButton, player, new HeatWave(), punch, pointCounterText);
        heatWave.offsetX = -240;
        heatWave.offsetY = punch.offsetY - 100;
        punch.AddLeftChild(heatWave);

        skillButton = Instantiate(skillButtonPrefab, transform);
        SkillButtonNode heal = skillButton.GetComponent<SkillButtonNode>();
        heal.Init(skillButton, player, new Heal(), punch, pointCounterText);
        heal.offsetX = 240;
        heal.offsetY = punch.offsetY - 100;
        
        punch.AddRightChild(heal);
        
        skillButton = Instantiate(skillButtonPrefab, transform);
        SkillButtonNode sacrifice = skillButton.GetComponent<SkillButtonNode>();
        sacrifice.Init(skillButton, player, new Sacrifice(), heal, pointCounterText);

        heal.AddChild(sacrifice);
    }

    void Awake() {
        Init();
    }
}
