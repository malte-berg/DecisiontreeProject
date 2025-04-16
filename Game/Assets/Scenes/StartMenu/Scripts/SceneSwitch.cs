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

    public IEnumerator LoadScene(int sceneIndex) {

        // Add cutscene and next scene to load queue
        int from = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation csOp = SceneManager.LoadSceneAsync(10, LoadSceneMode.Additive);

        while(!csOp.isDone)
            yield return null;

        Scene cs = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(cs);
        GameObject[] GOs = cs.GetRootGameObjects();
        CutsceneManager CM = GOs[1].GetComponent<CutsceneManager>();
        CM.SwitchScene(from, sceneIndex, 0);

    }

}
