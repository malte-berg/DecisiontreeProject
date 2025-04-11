public abstract class Node {
    public Skill skill;

    public Node(Skill skill) {
        this.skill = skill;
    }

    public abstract void AddSkill(Skill skill);
}