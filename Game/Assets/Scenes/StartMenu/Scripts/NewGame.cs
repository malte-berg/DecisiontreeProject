using System.IO;
using UnityEngine;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    public AreaInitializer a;

    GameObject playerObject;

    void Awake(){

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        
        if(p != null)
            Destroy(p);

    }

    public void StartNewGame() {

        prepPlayerAndArea();
        
        new SaveManager().CreateSave(playerObject.GetComponent<Player>());
        GetComponent<SceneSwitch>().WithCutscene = 0;
        GetComponent<SceneSwitch>().SwitchScene(1);

    }

    public void Continue(){

        prepPlayerAndArea();

        string[] files = Directory.GetFiles("Saves");
        Save temp = new SaveManager().ReadSave(files[files.Length-1].Substring(6)); // Load latest save
        playerObject.GetComponent<Player>().LoadPlayer(temp);
        GetComponent<SceneSwitch>().SwitchScene(1);

    }

    private void prepPlayerAndArea() {
        a = GetComponent<AreaInitializer>();
        // Initialize regionItems in AreaData
        a.Init(); 

        // Try to find player game object
        playerObject = GameObject.FindGameObjectWithTag("Player");

        // If player game object does not exist, create it
        if (playerObject == null){
            playerObject = Instantiate(playerPrefab);
            playerObject.GetComponent<Player>().Init();
        }
    }
    
}
