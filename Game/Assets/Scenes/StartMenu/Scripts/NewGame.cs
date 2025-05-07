using System.IO;
using UnityEngine;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    public AreaInitializer a;

    void Awake(){

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        
        if(p != null)
            Destroy(p);

    }

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
        
        new SaveManager().CreateSave(playerObject.GetComponent<Player>());
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

        string[] files = Directory.GetFiles("Saves");
        Save temp = new SaveManager().ReadSave(files[files.Length-1].Substring(6)); // Load latest save
        playerObject.GetComponent<Player>().LoadPlayer(temp);
        GetComponent<SceneSwitch>().SwitchScene(1);

    }
    
}
