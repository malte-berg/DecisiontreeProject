using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TEMP : MonoBehaviour{

    public Image backgroundImage;
    private Player player;
    private int currentAreaIndex;

    private AreaData currentArea;

    void Awake() {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.HidePlayer();
        TMP_Text combatCounter = transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        combatCounter.text = $"{player.CombatsWon}";
        float redness = (float)player.CombatsWon / 20;
        combatCounter.faceColor = new Color(1,1-redness,1-redness);

        if(player.CombatsWon > 10)
            combatCounter.faceColor = new Color(0.7f,0.7f,0.7f);
        else if(player.CombatsWon == 10) {
            combatCounter.fontMaterial.EnableKeyword("UNDERLAY_ON");
            combatCounter.fontMaterial.EnableKeyword("OUTLINE_ON");
            combatCounter.faceColor = new Color(0.7f,0,0);
        }

        // try to avoid unnecessary performance overhead
        if (currentAreaIndex != player.CurrentAreaIndex)
        {
            currentAreaIndex = player.CurrentAreaIndex;
            UpdateBackground();
        } 
    }

    void UpdateBackground()
    {
        // Debug.Log(currentAreaIndex);
        currentArea = AreaDataLoader.Load(currentAreaIndex);
        backgroundImage.sprite = currentArea.backgroundImage;
    }
}
