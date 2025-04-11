using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    GameObject playerObject;

    public void StartNewGame() {

        // For test
        Item[] regionItems = new Item[]{
            new Knife(),
            new Pipe(),
            new BrassKnuckles(),
            new Jacket(),
            new CombatJacket(),
            new Bucket(),
            new BicycleHelmet(),
            new WorkerBoots()
        };
        AreaDataLoader.InitAreaRegionItems(1,regionItems);

        // Try to find player game object
        playerObject = GameObject.Find("Player");

        // If player game object does not exist, create it
        if (playerObject == null) {
            Instantiate(playerPrefab).GetComponent<Player>().Init();
        } // Else, just continue with already created player
        
        SceneManager.LoadScene("InGameMenu");

    }
    
}
