using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Button[] buttons;
    private Player player;
    // public int MaxlevelIntex;

    private void Awake()
    {

        player = GameObject.Find("Player").GetComponent<Player>();

    }

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
        /* temporary use */
        if (clickedButton.name == "Area1")
        {
            Debug.Log("Area 1 clicked");
            AreaDataLoader.MovePlayerToArea(player, 1);
        }
        if (clickedButton.name == "Area2")
        {
            Debug.Log("Area 2 clicked");
            AreaDataLoader.MovePlayerToArea(player, 2);
        }
        else if (clickedButton.name == "Area3")
        {
            AreaDataLoader.MovePlayerToArea(player, 3);
            Debug.Log("Area 3 clicked");
        }
    }


}