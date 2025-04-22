using UnityEngine;
public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    public AreaInitializer a;

    public void StartNewGame() {

        a = GetComponent<AreaInitializer>();
        // Initialize regionItems in AreaData
        a.Init(); 

        // Try to find player game object
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // If player game object does not exist, create it
        if (playerObject == null){
            playerObject = Instantiate(playerPrefab);
            playerObject.GetComponent<Player>().Init();
        }
        
        GetComponent<SaveManager>().CreateSave(playerObject.GetComponent<Player>());
        GetComponent<SceneSwitch>().WithCutscene = 0;
        GetComponent<SceneSwitch>().SwitchScene(1);

    }

    public void Continue(){

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // If player game object does not exist, create it
        if (playerObject == null){
            playerObject = Instantiate(playerPrefab);
            playerObject.GetComponent<Player>().Init();
        }

        // TODO make this load latest save
        Save temp = GetComponent<SaveManager>().ReadSave("20250417165550");
        playerObject.GetComponent<Player>().LoadPlayer(temp);
        GetComponent<SceneSwitch>().SwitchScene(1);

    }
    
}
