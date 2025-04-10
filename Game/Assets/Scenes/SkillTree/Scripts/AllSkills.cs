using UnityEngine;
using System.Linq;

public class AllSkills : MonoBehaviour
{

    Player player;

    public Skill[] allSkills;

    /* There is an issue with this part: Every time the Skill Tree interface is opened, a new allSkills[] array is generated. When the corresponding skill button is clicked to upgrade, the newly generated skills in allSkills[] is passed to the HandleSkillClick function. This means that when the player upgrades a skill like Punch, exits the Skill Tree, and then re-enters and upgrades Punch again, the allSkills[0].unlocked will be false, even though Punch was previously unlocked and the player's skills[] already contains Punch. */
    public void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();

        allSkills = new Skill[16];
        allSkills[0] = new Punch(player);
        allSkills[1] = new HeatWave(player);
        allSkills[2] = new Heal(player);
        allSkills[3] = new Sacrifice(player);
    }

    void Awake()
    {

        Init();

    }

    /*
        AllSkills is placed on Canvas. On each skill button, the onClick() can be bound to the Canvas, with the AllSkills method 
        SkillTreeClick, taking in the name of the skill (as described in the skill). This will send the skill to unlock/upgrade
        in the AbilityManager, taking in a skill and deciding what to do based on what is sent in.
    */
    public void SkillTreeClick(string skillName) {

        Debug.Log($"Clicked on skill {skillName}");

        Skill skillToHandle = allSkills.SingleOrDefault(skill => skill != null && skill.Name.Equals(skillName));
        
        GetComponent<AbilityManager>().HandleSkillClick(skillToHandle);
        Debug.Log($"Skill {skillToHandle.Name} has power level: {skillToHandle.power}");
    }

}
