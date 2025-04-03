using UnityEngine;

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
    }

    void Awake()
    {

        Init();

    }

    public void SkillTreeClick(int index) {
        if (index < 0 || index >= allSkills.Length) {
            Debug.Log("Invalid skill index");
            return;
        }

        Debug.Log($"Clicked on skill {index}");

        Skill skill = allSkills[index];
        GetComponent<AbilityManager>().HandleSkill(skill);
    }

}
