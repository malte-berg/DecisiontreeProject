using UnityEngine;
using TMPro;

public class WinScreenLogic : MonoBehaviour
{
    public GameObject goldText;
    public GameObject expText;

    void Init() {
        goldText.GetComponent<TMP_Text>().text = "Gold: " + WinScreenData.goldEarned;
        expText.GetComponent<TMP_Text>().text = "Exp: " + WinScreenData.expEarned;
    }

    void Awake()
    {
        Init();
    }
}
