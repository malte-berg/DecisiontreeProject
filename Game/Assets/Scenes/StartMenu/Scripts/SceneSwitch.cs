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
        // SceneManager.LoadScene(sceneName);
        StartCoroutine(SwitchScene(sceneName, curr));

    }

    IEnumerator SwitchScene(string final, string curr){

        SceneManager.LoadScene("Cutscene", LoadSceneMode.Additive);
        SceneManager.LoadScene(final, LoadSceneMode.Additive);

        Scene nextScene = SceneManager.GetSceneByName("Cutscene");
        int timeout = 200;
        while ((!nextScene.IsValid() || !nextScene.isLoaded) && timeout-- > 0)
            yield return null;

        if(!nextScene.IsValid())
            Debug.LogError("NOT VALID");

        if(!nextScene.isLoaded)
            Debug.LogError("NOT LOADED");

        if(nextScene.IsValid() && nextScene.isLoaded)
            SceneManager.SetActiveScene(nextScene);
        else
            Debug.LogError("SwitchScene messed up.");
        
        SceneManager.UnloadSceneAsync(curr);

    }

}
