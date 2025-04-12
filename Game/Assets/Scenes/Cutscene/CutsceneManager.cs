using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour{

    public SceneScript[] sceneScripts;

    void Start(){

        StartCoroutine(Loading());

    }

    IEnumerator Loading(){

        // Wait for previous scene to unload
        print($"{SceneManager.GetSceneAt(0).name} is perhaps equal to: {SceneManager.GetActiveScene().name}");
        while(SceneManager.GetSceneAt(0) != SceneManager.GetActiveScene()){
            print($"{SceneManager.GetSceneAt(0).name} is perhaps equal to: {SceneManager.GetActiveScene().name}");
            yield return null;
        }

        int cs = -1;
        Player p = GameObject.Find("Player").GetComponent<Player>();

        if(p != null)
            cs = p.Cutscene;

        if(cs != -1)
            yield return StartCoroutine(DoAnimation(cs));
        
        StartCoroutine(EndCutscene());

    }

    IEnumerator DoAnimation(int i){

        GameObject[] rootObjects = SceneManager.GetSceneAt(1).GetRootGameObjects();
        foreach (GameObject obj in rootObjects) obj.SetActive(false);
        yield return StartCoroutine(sceneScripts[i].RunAnimation().GetEnumerator());
        foreach (GameObject obj in rootObjects) obj.SetActive(true);

    }

    IEnumerator EndCutscene(){

        string temp = "SCENES RN:\n";

        for(int i = 0; true; i++){
            try{
                temp += $"[{i}] {SceneManager.GetSceneAt(i).name}\n";
            } catch {
                print(temp);
                break;
            }
        }

        while(!SceneManager.GetSceneAt(1).isLoaded)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(0));

    }
    
}
