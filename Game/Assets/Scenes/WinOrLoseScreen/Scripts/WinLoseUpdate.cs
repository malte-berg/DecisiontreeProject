using UnityEngine;
using TMPro;

public class WinLoseUpdate : MonoBehaviour
{
    public GameObject goldText;
    public GameObject expText;

    void Init() {
        goldText.GetComponent<TMP_Text>().text = "Gold: " + RewardData.goldEarned;
        expText.GetComponent<TMP_Text>().text = "Exp: " + RewardData.expEarned;
    }

    void Awake()
    {
        Init();
    }
}
