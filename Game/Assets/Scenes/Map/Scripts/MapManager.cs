using TMPro;
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
        if (clickedButton.name == "Area1") {
            AreaDataLoader.MovePlayerToArea(player, 1);
            if(player.CombatsWon > 0) return;
            SceneSwitch sw = GetComponent<SceneSwitch>();
            // sw.WithCutscene = /* Area1 intro */;
            sw.SwitchScene(1);
        }
        if (clickedButton.name == "Area2") {

            if(player.CombatsArr[1] < 11){

                AreaLockedAlert(clickedButton.transform);
                return;

            }

            AreaDataLoader.MovePlayerToArea(player, 2);
            if(player.CombatsWon > 0) return;
            SceneSwitch sw = GetComponent<SceneSwitch>();
            // sw.WithCutscene = /* Area2 intro */;
            sw.SwitchScene(1);

        }
        else if (clickedButton.name == "Area3") {

            if(player.CombatsArr[2] < 11){

                AreaLockedAlert(clickedButton.transform);
                return;

            }
            AreaDataLoader.MovePlayerToArea(player, 3);
            if(player.CombatsWon > 0) return;
            SceneSwitch sw = GetComponent<SceneSwitch>();
            // sw.WithCutscene = /* Area3 intro */;
            sw.SwitchScene(1);
        }
    }

    void AreaLockedAlert(Transform where){
        
        GameObject temp = Instantiate(where.gameObject, where);
        GameObject alert = temp.transform.GetChild(0).gameObject;
        alert.transform.SetParent(temp.transform.parent);
        Destroy(temp);
        alert.name = "DefeatBossBefore";
        RectTransform rt = alert.GetComponent<RectTransform>();
        rt.localPosition = Vector3.zero;
        rt.sizeDelta *= 3;
        TMP_Text tx = alert.GetComponent<TMP_Text>();
        tx.text = "Defeat previous boss first!";
        tx.fontSize = 14;
        tx.color = Color.red;
        Destroy(alert, 3);

    }


}