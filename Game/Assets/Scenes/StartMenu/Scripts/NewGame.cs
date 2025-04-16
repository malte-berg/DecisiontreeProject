using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    public AreaInitializer ai;

    public void StartNewGame() {

        ai = GetComponent<AreaInitializer>();
        ai.Init();

        // Try to find player game object
        GameObject playerObject = GameObject.Find("Player");

        // If player game object does not exist, create it
        if (playerObject == null) {
            Instantiate(playerPrefab).GetComponent<Player>().Init();
        } // Else, just continue with already created player
        
        GetComponent<SceneSwitch>().WithCutscene = 0;
        GetComponent<SceneSwitch>().SwitchScene(1);

    }
    
}
