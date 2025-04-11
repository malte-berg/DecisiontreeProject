
public class SkillTreeTree {
    public SkillTreeRoot root;
    public Node currentNode;
    public GameCharacter player;
    public SkillTreeTree(Player player) {
        this.player = player;
        root = new SkillTreeRoot(null, null);
        currentNode = root;
    }

    public void AddSkill(Skill skill) {
        if (currentNode == null) {
            Debug.Log("Current node is null");
            return;
        }
        currentNode.AddSkill(skill);
    }

    public void MoveToAttacking() {
        currentNode = root.attacking;
        if (currentNode == null) {
            Debug.Log("Current node is null");
            return;
        }
    }

    public void MoveToDefending() {
        currentNode = root.defending;
        if (currentNode == null) {
            Debug.Log("Current node is null");
            return;
        }
    }

    public void MoveToParent() {
        if (currentNode == root) {
            Debug.Log("Current node is root");
            return;
        }

        currentNode = currentNode.parent;

        if (currentNode == null) {
            Debug.Log("Current node is null");
            return;
        }
    }

    public void MoveToChild() {
        if (currentNode == null) {
            Debug.Log("Current node is null");
            return;
        }

        currentNode = currentNode.child;

        if (currentNode == null) {
            Debug.Log("Current node is null");
            return;
        }
    }

    public void FindSkill(Skill skill) {
        if (FindInBranch(root.attacking, skill)) {
            Debug.Log("Skill found in attacking branch: " + skill.Name);
            return;
        }
        if (FindInBranch(root.defending, skill)) {
            Debug.Log("Skill found in defending branch: " + skill.Name);
            return;
        }
        Debug.Log("Skill not found: " + skill.Name);
        currentNode = null;
    }

    bool FindInBranch(SkillTreeNode node, Skill skill) {
        if (node == null) {
            return false;
        }

        if (node.skill != null && node.skill.Name == skill.Name) {
            Debug.Log("Skill found: " + node.skill.Name);
            currentNode = node;
            return true;
        }

        TraverseBranch(node.child, skill);
    }

}