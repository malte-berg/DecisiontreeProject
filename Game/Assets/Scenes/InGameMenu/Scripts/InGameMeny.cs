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
