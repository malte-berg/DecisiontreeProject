using System;

public class SkillBook {

    Type[] pages = {
        typeof(Punch),
        typeof(HeatWave),
        typeof(Heal),
        typeof(Sacrifice),
        typeof(Zap),
        typeof(Corrode),
        typeof(MindControl),
        typeof(Shield)
    };

    public int Count{ get{ return pages.Length; }}

    public Skill[] CreateSkillBook(){

        Skill[] temp = new Skill[pages.Length];

        for(int i = 0; i < pages.Length; i++)
            temp[i] = ReadPage(i);

        return temp;

    }

    public Skill ReadPage(int index){

        return Activator.CreateInstance(pages[index]) as Skill;
        
    }

}