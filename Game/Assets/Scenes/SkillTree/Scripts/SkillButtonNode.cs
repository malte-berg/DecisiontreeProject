using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillButtonNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject self;
    public GameObject skillName;
    public GameObject hoverPanelPrefab;
    private TMP_Text pointsCounter;
    public Player player;
    public Skill skill;
    public SkillButtonNode parent;
    public SkillButtonNode right;
    public SkillButtonNode left;
    public int offsetX;
    public int offsetY;
    RectTransform rt;

    GameObject hoverPanelInstance;
    Vector2 toolTipOffset;
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
        toolTipOffset.x = 40;
        toolTipOffset.y = 135;
        rt = GetComponent<RectTransform>();
        
        SetNode();
    }

    public void SetNode() {
        Image imageComponent = self.GetComponent<Image>();
        TMP_Text skillNameText = skillName.GetComponent<TMP_Text>();

        if (imageComponent != null) {
            imageComponent.sprite = skill.Icon;
            if (skill.unlocked) {
                imageComponent.color = Color.white;
            } else {
                imageComponent.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            } 
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
        if (!skill.unlocked && (parent == null || parent.skill.unlocked)) {
            skill.UnlockSkill(player);
            player.AddSkill(skill);
            player.SkillPoints -= skill.skillCost;
            Debug.Log($"Unlocked {skill.Name}!");
        }
        SetNode();
        UpdateToolTip();
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

    override public string ToString() {
        string result = "SkillButtonNode: " + skill.Name + "\n";
        result += "Parent: " + (parent != null ? parent.skill.Name : "null") + "\n";
        result += "Left Child: " + (left != null ? left.skill.Name : "null") + "\n";
        result += "Right Child: " + (right != null ? right.skill.Name : "null") + "\n";
        return result;
    }

    public void MoveNode() {
        rt.anchoredPosition = new Vector2(offsetX, offsetY);
    }

    public void DrawLine() {
        if (parent != null) {
            GameObject rect = new GameObject("Line");
            rect.layer = LayerMask.NameToLayer("UI");
            RectTransform rectTransform = rect.AddComponent<RectTransform>();

            float startRadius = self.GetComponent<RectTransform>().sizeDelta.x / 2;
            float endRadius = parent.GetComponent<RectTransform>().sizeDelta.x / 2;

            rectTransform.SetParent(transform, false);

            Vector2 startPos = rt.anchoredPosition;
            Vector2 endPos = parent.rt.anchoredPosition;

            Vector2 direction = (endPos - startPos).normalized;

            startPos -= (Vector2) (direction * startRadius);
            endPos += (Vector2) (direction * endRadius);
            float xDelta = endPos.x - startPos.x;
            float yDelta = endPos.y - startPos.y;

            startPos = new Vector2(0, 0);
            endPos = new Vector2(xDelta, yDelta);

            Vector2 midPos = (startPos + endPos) / 2;

            float distance = Vector2.Distance(startPos, endPos);
            float angle = Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg;

            rectTransform.sizeDelta = new Vector2(distance, 5f);
            rectTransform.anchoredPosition = midPos;
            rectTransform.rotation = Quaternion.Euler(0, 0, angle);

            Image lineImage = rect.AddComponent<Image>();
            lineImage.color = Color.white;
            
            rectTransform.SetParent(transform.parent.transform);
            rectTransform.SetSiblingIndex(0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {

        if (hoverPanelPrefab != null && hoverPanelInstance == null) {

            hoverPanelInstance = Instantiate(hoverPanelPrefab, transform);
            
            UpdateToolTip();

            RectTransform buttonRectTransform = GetComponent<RectTransform>();
            RectTransform toolTipTransform = hoverPanelInstance.GetComponent<RectTransform>();

            Vector3[] buttonCorners = new Vector3[4];
            buttonRectTransform.GetWorldCorners(buttonCorners);

            toolTipTransform.anchoredPosition = toolTipOffset;
        }

    }

    public void OnPointerExit(PointerEventData eventData) {

        if (hoverPanelInstance != null) {

            Destroy(hoverPanelInstance);

        }

    }

    void UpdateToolTip() {
        if (hoverPanelInstance != null) {
            hoverPanelInstance.transform.GetChild(1).GetComponent<TMP_Text>().text = skill.Name;
            hoverPanelInstance.transform.GetChild(2).GetComponent<TMP_Text>().text = skill.Description;
            TMP_Text levelText = hoverPanelInstance.transform.GetChild(3).GetComponent<TMP_Text>();

            if (skill.unlocked) {
                levelText.text = "Level: " + skill.SkillLevel.ToString();
            } else if (parent != null && !parent.skill.unlocked) {
                levelText.text = "Unlock " + parent.skill.Name + " first!";
            } else {
                levelText.text = "Unlock";
            }
        }
    }
}
