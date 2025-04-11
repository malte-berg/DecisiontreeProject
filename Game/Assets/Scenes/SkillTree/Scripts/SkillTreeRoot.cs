public class SkillTreeRoot : Node {
    public SkillTreeNode attacking;
    public SkillTreeNode defending;

    public SkillTreeRoot(Skill skill): base(skill) {
        attacking = new SkillTreeNode(null, null);
        defending = new SkillTreeNode(null, null);
    }

    public void AddAttackingSkill() {
        if (attacking == null) {
            Debug.Log("Attacking node is null");
            return;
        }
        attacking.AddSkill(skill);
    }

    public void AddDefendingSkill() {
        if (defending == null) {
            Debug.Log("Defending node is null");
            return;
        }
        defending.AddSkill(skill);
    }
}