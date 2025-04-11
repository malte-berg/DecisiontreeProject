public class SkillTreeNode : Node {
    public Node parent;
    public SkillTreeNode child;

    public SkillTreeNode(Skill skill, SkillTreeNode parent) : base(skill) {
        this.parent = parent;
        this.child = null;
    }

    public void AddSkill(Skill skill) {
        if (child == null) {
            child = new SkillTreeNode(skill, this);
        } else {
            child.AddSkill(skill);
        }
    }
}