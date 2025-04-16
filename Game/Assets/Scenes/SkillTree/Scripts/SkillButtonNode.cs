using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
        if (parent != null) {
            GameObject rect = new GameObject("Line");
            rect.layer = LayerMask.NameToLayer("UI");
            RectTransform rectTransform = rect.AddComponent<RectTransform>();

            float startRadius = self.GetComponent<RectTransform>().sizeDelta.x / 2;
            float endRadius = parent.GetComponent<RectTransform>().sizeDelta.x / 2;

            Canvas canvas = GetComponentInParent<Canvas>();
            if (canvas == null) {
                Debug.LogError("Canvas not found in parent.");
                return;
            }
            rectTransform.SetParent(canvas.transform, false);

            Vector3 startPos = self.transform.position;
            Vector3 endPos = parent.transform.position;
            startPos.z = -1;
            endPos.z = -1;

            Vector3 direction = (endPos - startPos).normalized;

            startPos -= (Vector3) (direction * startRadius);
            endPos += (Vector3) (direction * endRadius);

            Vector3 midPos = (startPos + endPos) / 2;

            float distance = Vector3.Distance(startPos, endPos);
            float angle = Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg;

            rectTransform.sizeDelta = new Vector2(distance, 5f);
            rectTransform.position = midPos;
            rectTransform.rotation = Quaternion.Euler(0, 0, angle);

            Image lineImage = rect.AddComponent<Image>();
            lineImage.color = Color.white;
            rectTransform.SetAsFirstSibling();
        }
    }
}
