using System.Collections.Generic;
using UnityEngine;

public class SkillTreeTree {
    public SkillButtonNode root;
    public Player player;

    public enum SkillType {
        Defense,
        Attack
    }

    public SkillTreeTree(Player player) {
        this.player = player;
        root = null;
    }

    public List<SkillButtonNode> GetAllNodes() {
        List<SkillButtonNode> nodes = new List<SkillButtonNode>();
        GetAllNodeRecursive(root, nodes);
        return nodes;
    }

    void GetAllNodeRecursive(SkillButtonNode node, List<SkillButtonNode> nodes) {
        if (node == null) {
            return;
        }
        nodes.Add(node);
        GetAllNodeRecursive(node.left, nodes);
        GetAllNodeRecursive(node.right, nodes);
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

    public void AddNode(SkillButtonNode newNode) {
        if (root == null) {
            root = newNode;
            return;
        }

        root.AddChild(newNode);
    }
}