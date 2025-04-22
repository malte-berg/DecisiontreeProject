using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour{

    public GameObject dialogueBoxGO;
    public SceneScript[] sceneScripts;
    GameObject canvas;

    public void SwitchScene(int from, int to, int cutscene){

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        AsyncOperation departingOp = SceneManager.UnloadSceneAsync(from);
        StartCoroutine(DoCutscene(departingOp, to, cutscene));

    }

    IEnumerator DoCutscene(AsyncOperation from, int to, int cutscene){

        while(!from.isDone)
            yield return null;

        AsyncOperation arrivingSceneOp = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        arrivingSceneOp.allowSceneActivation = false;

        if(cutscene >= 0 && cutscene < sceneScripts.Length) {

            sceneScripts[cutscene].LoadCutscene(dialogueBoxGO, canvas.transform);
            yield return sceneScripts[cutscene].RunAnimation();

        }

        Destroy(canvas);
        arrivingSceneOp.allowSceneActivation = true;

        while(!arrivingSceneOp.isDone)
            yield return null;

        Scene arrivingScene = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(arrivingScene);
        SceneManager.UnloadSceneAsync(10);

    }

    // TODO create save using AsyncOperation

}
