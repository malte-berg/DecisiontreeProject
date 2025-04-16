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

    public int offsetX;
    public int offsetY;

    public void Init(GameObject node, Player player, Skill skill, SkillButtonNode parent, TMP_Text pointsCounter) {
        self = node;
        this.player = player;
        this.skill = skill;
        this.parent = parent;
        this.right = null;
        this.left = null;
        this.offsetX = 0;
        this.offsetY = 0;
        this.pointsCounter = pointsCounter;

        MoveNode();
        SetNode();
    }

    public void SetNode() {
        Image imageComponent = self.GetComponent<Image>();
        TMP_Text skillNameText = skillName.GetComponent<TMP_Text>();
        TMP_Text skillLevelText = skillLevel.GetComponent<TMP_Text>();

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
        } 
        if (!skill.unlocked && (parent.skill.unlocked || parent == null)) {
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
            child.offsetX = this.offsetX + this.offsetX / 2;
            child.offsetY = this.offsetY - 100;
            child.MoveNode();
            child.DrawLine();
            return true;
        } 
        if (right == null){
            right = child;
            child.parent = this;
            child.offsetX = this.offsetX + this.offsetX / 2;
            child.offsetY = this.offsetY - 100;
            child.MoveNode();
            child.DrawLine();
            return true;
        }

        if (left.AddChild(child)){
            return true;
        } else if(right.AddChild(child)){
            return true;
        }
        return false;
    }

    public void AddLeftChild(SkillButtonNode child) {
        left = child;
        child.parent = this;
        child.MoveNode();
        child.DrawLine();
    }

    public void AddRightChild(SkillButtonNode child) {
        right = child;
        child.parent = this;
        child.MoveNode();
        child.DrawLine();
    }

    public string ToString() {
        string result = "SkillButtonNode: " + skill.Name + "\n";
        //result += "Skill Level: " + skill.SkillLevel + "\n";
        //result += "Skill Cost: " + skill.skillCost + "\n";
        //result += "Skill Points: " + player.SkillPoints + "\n";
        result += "Parent: " + (parent != null ? parent.skill.Name : "null") + "\n";
        result += "Left Child: " + (left != null ? left.skill.Name : "null") + "\n";
        result += "Right Child: " + (right != null ? right.skill.Name : "null") + "\n";
        return result;
    }

    public void MoveNode() {
        self.transform.position = new Vector3(offsetX + self.transform.position.x, offsetY + self.transform.position.y, 0);
    }

    public void DrawLine() {
        Debug.Log("Drawing line from " + self.name + " to " + (parent != null ? parent.self.name : "null"));
        if (parent != null) {
            LineRenderer lineRenderer = self.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, self.transform.position);
            lineRenderer.SetPosition(1, parent.self.transform.position);
        }
    }
}
