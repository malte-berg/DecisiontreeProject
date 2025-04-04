using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedoStatsSceneSwitch : MonoBehaviour
{
    //Quick fix, borde nog ändra det här
    public GameObject playerPrefab;

    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);

        //To reset the stats
        Destroy (GameObject.Find("Player"));
        print("Player seems to have been destroyed.");
        Instantiate(playerPrefab).GetComponent<Player>().Init();

    }
}
