using UnityEngine;
using TMPro;

public class WinLoseUpdate : MonoBehaviour
{
    public GameObject goldText;
    public GameObject expText;

    void Init() {
        goldText.GetComponent<TMP_Text>().text = "+" + RewardData.goldEarned + " Gold";
        expText.GetComponent<TMP_Text>().text = "+" + RewardData.expEarned + " EXP";
    }

    void Awake()
    {
        Init();
    }
}