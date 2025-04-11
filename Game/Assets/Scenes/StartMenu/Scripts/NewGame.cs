using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;

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

        Instantiate(playerPrefab).GetComponent<Player>().Init();
        SceneManager.LoadScene("InGameMenu");

    }
    
}
