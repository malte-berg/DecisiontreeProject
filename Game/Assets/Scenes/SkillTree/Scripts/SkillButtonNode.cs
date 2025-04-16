using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonNode : MonoBehaviour
{
    GameObject self;
    public GameObject skillName;
    public GameObject skillLevel;
    public Player player;
    public Skill skill;
    public SkillButtonNode parent;
    public SkillButtonNode right;
    public SkillButtonNode left;

    public void Init(GameObject node, Player player, Skill skill, SkillButtonNode parent) {
        self = node;
        this.player = player;
        this.skill = skill;
        this.parent = parent;
        this.right = null;
        this.left = null;

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
    }

    public void OnClick(){
        GetComponent<AllSkills>().SetPointCounter();
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

    public void AddChild(SkillButtonNode child) {
        if (left == null){
            left = child;
            child.parent = this;
        } else if (right == null){
            right = child;
            child.parent = this;
        } else {
            left.AddChild(child);
        }
    }

    public void AddLeftChild(SkillButtonNode child) {
        if (left == null) {
            left = child;
            child.parent = this;
        } else {
            left.AddLeftChild(child);
        }
    }

    public void AddRightChild(SkillButtonNode child) {
        if (right == null) {
            right = child;
            child.parent = this;
        } else {
            left.AddRightChild(child);
        }
    }
}
