using UnityEngine;
using System.Linq;

public class AllSkills : MonoBehaviour
{

    Player player;

    public Skill[] allSkills;

    public void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();

        allSkills = new Skill[16];
        allSkills[0] = new Punch(player);
        allSkills[1] = new HeatWave(player);
        allSkills[2] = new Heal(player);
        allSkills[3] = new Sacrifice(player);
        allSkills[4] = new Poison(player);
    }

    void Awake()
    {

        Init();

    }

<<<<<<< HEAD
    public void SkillTreeClick(int index)
    {
        if (index < 0 || index >= allSkills.Length)
        {
            Debug.Log("Invalid skill index");
            return;
        }
=======
    /*
        AllSkills is placed on Canvas. On each skill button, the onClick() can be bound to the Canvas, with the AllSkills method 
        SkillTreeClick, taking in the name of the skill (as described in the skill). This will send the skill to unlock/upgrade
        in the AbilityManager, taking in a skill and deciding what to do based on what is sent in.
    */
    public void SkillTreeClick(string skillName) {
>>>>>>> upstream/main

        Debug.Log($"Clicked on skill {skillName}");

        Skill skillToHandle = allSkills.SingleOrDefault(skill => skill != null && skill.Name.Equals(skillName));
        
        GetComponent<AbilityManager>().HandleSkillClick(skillToHandle);
        Debug.Log($"Skill {skillToHandle.Name} has power level: {skillToHandle.power}");
    }

}
