using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    void Awake(){

        if(SceneManager.GetActiveScene().name == "StartMenu")
            return;

        GameObject p = GameObject.Find("Player");

        if(p == null)
            SceneManager.LoadScene("StartMenu");
        else
            p.GetComponent<Player>().HidePlayer();

    }

    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
