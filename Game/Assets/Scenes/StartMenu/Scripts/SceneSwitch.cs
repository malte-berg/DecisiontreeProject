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

    /// <summary>
    /// Should switch scene but also ask the cutscene manager to perchance do a cutscene
    /// AKA load cutscene and next scene in that order, then unload itself
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName) {

        StartCoroutine(SwitchScene(sceneName));

    }

    IEnumerator SwitchScene(string destination){

        // var asyncLoad = SceneManager.LoadSceneAsync("Cutscene", LoadSceneMode.Additive);

        string temp = "SCENES RN:\n";

        for(int i = 0; true; i++){
            try{
                temp += $"[{i}] {SceneManager.GetSceneAt(i).name}\n";
            } catch {
                print(temp);
                break;
            }
        }

        // Add cutscene and next scene to load queue
        
        SceneManager.LoadScene("Cutscene", LoadSceneMode.Additive);
        SceneManager.LoadScene(destination, LoadSceneMode.Additive);

        /*
        int timeout = 200;
        while ((!nextScene.IsValid() || !nextScene.isLoaded) && timeout-- > 0)
            yield return null;

        if(!nextScene.IsValid())
            Debug.LogError("NOT VALID");

        if(!nextScene.isLoaded)
            Debug.LogError("NOT LOADED");

        if(nextScene.IsValid() && nextScene.isLoaded) */
        // while(!asyncLoad.isDone)

        // Wait for cutscene to load
        while(!SceneManager.GetSceneAt(1).isLoaded)
            yield return null;

        // Set cutscene to primary
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        print($"NEW ACTIVE SCENE: {SceneManager.GetActiveScene().name}");
        /* else
            Debug.LogError("SwitchScene messed up."); */
        
        // Unload current scene
        SceneManager.UnloadSceneAsync(0);

    }

}
