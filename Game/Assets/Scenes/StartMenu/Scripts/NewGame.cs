using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;
    public AreaInitializer ai;

    public void StartNewGame() {

        ai = GetComponent<AreaInitializer>();
        ai.Init();

        Instantiate(playerPrefab).GetComponent<Player>().Init();
        SceneManager.LoadScene("InGameMenu");

    }
    
}
