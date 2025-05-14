using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class AllSkills : MonoBehaviour {
    public TMP_Text pointCounterText;

    public GameObject skillButtonPrefab;
    Player player;
    SkillTreeTree stt;
    public GameObject skillTreePanel;
    public Image bg;

    public void Init() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();
        RectTransform panelRect = skillTreePanel.GetComponent<RectTransform>();

        // Initialize the skill tree with the skills
        stt = new SkillTreeTree(player);

        GameObject skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode punch = skillButton.GetComponent<SkillButtonNode>();
        punch.Init(skillButton, player, player.skills[0], null, pointCounterText);
        punch.offsetX = 0;
        punch.offsetY = getYFromDepth(1);
        punch.MoveNode();

        stt.AddNode(punch);

        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode heatWave = skillButton.GetComponent<SkillButtonNode>();
        heatWave.Init(skillButton, player, new HeatWave(), punch, pointCounterText);
        heatWave.offsetX = -160;
        heatWave.offsetY = getYFromDepth(2);
        punch.AddLeftChild(heatWave);

        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode heal = skillButton.GetComponent<SkillButtonNode>();
        heal.Init(skillButton, player, new Heal(), punch, pointCounterText);
        heal.offsetX = 160;
        heal.offsetY = getYFromDepth(2);
        punch.AddRightChild(heal);
        
        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode shield = skillButton.GetComponent<SkillButtonNode>();
        shield.Init(skillButton, player, new Shield(), heal, pointCounterText);
        shield.offsetX = 80;
        shield.offsetY = getYFromDepth(3);
        heal.AddLeftChild(shield);

        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode sacrifice = skillButton.GetComponent<SkillButtonNode>();
        sacrifice.Init(skillButton, player, new Sacrifice(), heal, pointCounterText);
        sacrifice.offsetX = 240;
        sacrifice.offsetY = getYFromDepth(3);
        heal.AddChild(sacrifice);

        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode zap = skillButton.GetComponent<SkillButtonNode>();
        zap.Init(skillButton, player, new Zap(), heatWave, pointCounterText);
        zap.offsetX = -240;
        zap.offsetY = getYFromDepth(3);
        heatWave.AddChild(zap);

        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode mindControl = skillButton.GetComponent<SkillButtonNode>();
        mindControl.Init(skillButton, player, new MindControl(), zap, pointCounterText);
        mindControl.offsetX = -300;
        mindControl.offsetY = getYFromDepth(4);
        zap.AddLeftChild(mindControl);

        skillButton = Instantiate(skillButtonPrefab, panelRect);
        SkillButtonNode corrode = skillButton.GetComponent<SkillButtonNode>();
        corrode.Init(skillButton, player, new Corrode(), zap, pointCounterText);
        corrode.offsetX = -180;
        corrode.offsetY = getYFromDepth(4);
        zap.AddChild(corrode);

        stt.UpdateNodes(punch);
    }

    private int getYFromDepth(int depth) {
        return depth * -100;
    }

    void setBackgrund(){
        AreaData ad = AreaDataLoader.Load(player.CurrentAreaIndex);
        bg.sprite = ad.backgroundImage;
    }

    void Awake() {
        Init();
        setBackgrund();
    }
}
