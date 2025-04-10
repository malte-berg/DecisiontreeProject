using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        ButtonInit();
    }

    void ButtonInit()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        // When there are too many buttons may want to consider using another method instead of if-else for optimization
        if (clickedButton.name == "Area1")
        {
            Debug.Log("Area 1 clicked");
        }
        else if (clickedButton.name == "Area2")
        {
            Debug.Log("Area 2 clicked");
        }
    }
}