using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonNode : MonoBehaviour
{
    GameObject self;
    public GameObject skillName;
    public GameObject skillLevel;
    private TMP_Text pointsCounter;
    public Player player;
    public Skill skill;
    public SkillButtonNode parent;
    public SkillButtonNode right;
    public SkillButtonNode left;

    public void Init(GameObject node, Player player, Skill skill, SkillButtonNode parent, TMP_Text pointsCounter) {
        self = node;
        this.player = player;
        this.skill = skill;
        this.parent = parent;
        this.right = null;
        this.left = null;
        this.pointsCounter = pointsCounter;

        SetNode();
    }

    public void SetNode() {
        Image imageComponent = self.GetComponent<Image>();
        TMP_Text skillNameText = skillName.GetComponent<TMP_Text>();
        TMP_Text skillLevelText = skillLevel.GetComponent<TMP_Text>();

        if (imageComponent == null) {
            imageComponent = self.AddComponent<Image>();
        }

        if (skillNameText == null) {
            skillNameText = self.AddComponent<TMP_Text>();
        }

        if (skillLevelText == null) {
            skillLevelText = self.AddComponent<TMP_Text>();
        }

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

        if (skillNameText != null){
            skillNameText.text = skill.Name;
        }

        if (pointsCounter != null) {
            pointsCounter.text = player.SkillPoints.ToString();
        }
    }

    public void OnClick(){
        if (skill == null) {
            Debug.Log("Skill not found");
            return;
        }
        if (skill.skillCost > player.SkillPoints) {
            Debug.Log("Not enough skill points!");
            return;
        }
        if (skill.unlocked) {
            skill.UpgradeSkill();
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Upgraded {skill.Name}!");
        } else {
            skill.UnlockSkill(player);
            player.AddSkill(skill);
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Unlocked {skill.Name}!");
        }
        SetNode();
    }

    public bool AddChild(SkillButtonNode child) {
        if (left == null){
            left = child;
            child.parent = this;
            return true;
        } 
        if (right == null){
            right = child;
            child.parent = this;
            return true;
        }

        if (left.AddChild(child)){
            return true;
        } else if(right.AddChild(child)){
            return true;
        }
        return false;
    }
}
