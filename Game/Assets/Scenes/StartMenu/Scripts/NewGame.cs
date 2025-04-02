using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour{

    public GameObject playerPrefab;

    public void StartNewGame() {

        Instantiate(playerPrefab).GetComponent<Player>().Init();
        SceneManager.LoadScene("InGameMenu");

    }
    
}
