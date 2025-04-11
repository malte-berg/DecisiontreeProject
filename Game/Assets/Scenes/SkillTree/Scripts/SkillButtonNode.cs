using UnityEngine;

public class SkillButtonNode : MonoBehaviour
{
    public GameObject thisNode;
    public Skill skill;
    public SkillButtonNode parent;
    public SkillButtonNode right;
    public SkillButtonNode left;

    public void Init(Skill skill, SkillButtonNode parent) {
        this.skill = skill;
        this.parent = parent;
        this.right = null;
        this.left = null;
    }

    public void OnClick(){
        // TODO: Implement OnClick
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
