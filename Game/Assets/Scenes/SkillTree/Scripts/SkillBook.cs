public class SkillBook {

    Skill[] pages;

    public Skill[] Pages{ get { return pages; }}

    public void Load(){

        pages = new Skill[12];
        pages[0] = new Punch();
        pages[1] = new HeatWave();
        pages[2] = new Heal();
        pages[3] = new Sacrifice();

    }

    public Skill GetSkill(int index){

        if(pages.Length == 0) return null;
        return pages[index];
        
    }

}