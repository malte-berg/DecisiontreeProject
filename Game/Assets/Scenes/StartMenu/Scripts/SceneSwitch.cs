using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    // A check to see if we need to go to title screen
    void Awake(){

        if(SceneManager.GetActiveScene().buildIndex == 0)
            return;

        GameObject p = GameObject.Find("Player");

        if(p == null)

            LoadScene(0);
        else
            p.GetComponent<Player>().HidePlayer();

    }

    public void SwitchScene(int sceneIndex){

        StartCoroutine(LoadScene(sceneIndex));

    }

    /// <summary>
    /// Should switch scene but also ask the cutscene manager to perchance do a cutscene
    /// AKA load cutscene and next scene in that order, then unload itself
    /// </summary>
    /// <param name="sceneName"></param>
    public IEnumerator LoadScene(int sceneIndex) {

        string temp = "SCENES RN:\n";

        for(int i = 0; true; i++){
            try{
                temp += $"[{i}] {SceneManager.GetSceneAt(i).name}\n";
            } catch {
                print(temp);
                break;
            }
        }

        /// OK NOW LOAD SCENES ///
        // Add cutscene and next scene to load queue
        AsyncOperation csOp = SceneManager.LoadSceneAsync(10, LoadSceneMode.Additive);
        // csOp.allowSceneActivation = false;

        while(!csOp.isDone)
            yield return null;

        // csOp.allowSceneActivation = true;
        Scene cs = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(cs);
        GameObject[] GOs = cs.GetRootGameObjects();
        CutsceneManager CM = GOs[1].GetComponent<CutsceneManager>();
        StartCoroutine(CM.DoCutscene(SceneManager.GetSceneAt(0), sceneIndex, 0));

    }

}
