public class SkillBook {

    Skill[] pages;

    public Skill[] Pages{ get { return pages; }}

    public void Load(GameCharacter t){

        pages = new Skill[12];
        pages[0] = new Punch(t);
        pages[1] = new HeatWave(t);
        pages[2] = new Heal(t);
        pages[3] = new Sacrifice(t);

    }

    public Skill GetSkill(int index){

        if(pages.Length == 0) return null;
        return pages[index];
        
    }

}