using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour{

    public SceneScript[] sceneScripts;

    void Start(){

        int cs = -1;
        Player p = GameObject.Find("Player").GetComponent<Player>();

        if(p != null)
            cs = p.Cutscene;

        if(cs == -1)
            EndCutscene();
        else
            StartCoroutine(DoAnimations(cs));

    }

    IEnumerator DoAnimations(int i){

        GameObject[] rootObjects = SceneManager.GetSceneAt(2).GetRootGameObjects();
        foreach (GameObject obj in rootObjects) obj.SetActive(false);
        yield return StartCoroutine(sceneScripts[i].RunAnimation().GetEnumerator());
        foreach (GameObject obj in rootObjects) obj.SetActive(true);
        EndCutscene();

    }

    void EndCutscene(){

        SceneManager.UnloadSceneAsync("Cutscene");

    }
    
}
