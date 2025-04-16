using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    public AreaInitializer a;

    public void StartNewGame() {

        a = GetComponent<AreaInitializer>();
        /* Blir fel efter pull, ska fixa */
        // a.Init(); 

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
