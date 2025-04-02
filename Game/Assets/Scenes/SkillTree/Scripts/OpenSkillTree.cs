using UnityEngine;
using UnityEngine.UI;

public class OpenSkillTree : MonoBehaviour
{
    public GameObject[] skillNodes; // Assign skill nodes
    public GameObject[] skillLines; // Assign connecting lines

    private bool isVisible = false;

    void Start()
    {
        // Initially hide all skill nodes and lines
        SetSkillTreeActive(false);
    }

    public void ToggleSkillTree()
    {
        isVisible = !isVisible;
        Debug.Log("Toggling Skill Tree. isVisible = " + isVisible);
        SetSkillTreeActive(isVisible);
    }

    public void HideSkillTree()
    {
        if (isVisible) // Only hide if currently visible
        {
            isVisible = false;
            Debug.Log("Hiding Skill tree");
            SetSkillTreeActive(false);
        }

    }

    private void SetSkillTreeActive(bool state)
    {
        // Enable or disable skill nodes
        foreach (GameObject node in skillNodes)
        {
            node.SetActive(state);
        }

        // Enable or disable lines
        foreach (GameObject line in skillLines)
        {
            line.SetActive(state);
        }
    }
}
