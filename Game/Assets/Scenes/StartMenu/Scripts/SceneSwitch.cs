using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    void Awake(){

        if(SceneManager.GetActiveScene().name == "StartMenu")
            return;

        GameObject p = GameObject.Find("Player");

        if(p == null)
            LoadScene("StartMenu");
        else
            p.GetComponent<Player>().HidePlayer();

    }

    public void LoadScene(string sceneName) {

        string curr = SceneManager.GetActiveScene().name;
        StartCoroutine(SwitchScene(sceneName, curr));

    }

    IEnumerator SwitchScene(string final, string curr){

        SceneManager.LoadScene("Cutscene", LoadSceneMode.Additive);
        SceneManager.LoadScene(final, LoadSceneMode.Additive);

        yield return null;

        Scene nextScene = SceneManager.GetSceneByName("Cutscene");
        if (nextScene.IsValid() && nextScene.isLoaded)
            SceneManager.SetActiveScene(nextScene);

        SceneManager.UnloadSceneAsync(curr);

    }

}
