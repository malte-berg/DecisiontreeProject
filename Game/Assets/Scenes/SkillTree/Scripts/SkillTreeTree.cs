using System.Collections.Generic;
using UnityEngine;

public class SkillTreeTree {
    public SkillButtonNode root;
    public GameCharacter player;

    public enum SkillType {
        Defense,
        Attack
    }

    public SkillTreeTree(GameCharacter player) {
        this.player = player;
        root = null;
    }

    public List<Skill> GetAllSkills() {
        List<Skill> skills = new List<Skill>();
        GetAllSkillsRecursive(root, skills);
        return skills;
    }

    void GetAllSkillsRecursive(SkillButtonNode node, List<Skill> skills) {
        if (node == null) {
            return;
        }
        skills.Add(node.skill);
        GetAllSkillsRecursive(node.left, skills);
        GetAllSkillsRecursive(node.right, skills);
    }

    public SkillButtonNode FindSkill(string skillName) {
        return FindSkillRecursive(root, skillName);
    }

    SkillButtonNode FindSkillRecursive(SkillButtonNode node, string skillName) {
        if (node == null) {
            return null;
        }
        if (node.skill.Name == skillName) {
            return node;
        }
        SkillButtonNode foundNode = FindSkillRecursive(node.left, skillName);
        if (foundNode != null) {
            return foundNode;
        }
        return FindSkillRecursive(node.right, skillName);
    }

    public void AddNode(Skill skill, GameObject prefab) {
        if (root == null) {
            root = Instantiate(prefab);
            
        }
        SkillButtonNode newNode = new SkillButtonNode(skill, null);
        if (skillType == SkillType.Attack) {
            if(root.left != null) root.left.AddChild(newNode);
            else root.AddLeftChild(newNode);
        } else if (skillType == SkillType.Defense){
            if (root.right != null) root.right.AddChild(newNode);
            else root.AddRightChild(newNode);
        }
    }
    */
}