using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour{

    public SceneScript[] sceneScripts;

    void Start(){

        // StartCoroutine(Loading());

    }

    public IEnumerator DoCutscene(Scene from, int to, int cutscene){

        print($"From: {from.name}, To: {to}, Cutscene: {cutscene}");
        AsyncOperation departingOp = SceneManager.UnloadSceneAsync(from);
        AsyncOperation arrivingSceneOp = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        arrivingSceneOp.allowSceneActivation = false;

        print("STAGE1");

        while(!departingOp.isDone){
            print($"UNLOADING PREVIOUS SCENE: {departingOp.progress}%");
            yield return new WaitForEndOfFrame();
        }


        print("STAGE2");

        if(cutscene > -1){
            print("should start animation");
            yield return StartCoroutine(DoAnimation(cutscene));
        }

        arrivingSceneOp.allowSceneActivation = true;

        while(!arrivingSceneOp.isDone)
            yield return null;

        Scene arrivingScene = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(arrivingScene);
        SceneManager.UnloadSceneAsync(0);

    }

    IEnumerator Loading(){

        Scene previous = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        SceneManager.UnloadSceneAsync(previous);

        // Wait for previous scene to unload
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

        // GameObject[] rootObjects = SceneManager.GetSceneAt(1).GetRootGameObjects();
        // foreach (GameObject obj in rootObjects) obj.SetActive(false);
        print("animation start");
        yield return StartCoroutine(sceneScripts[i].RunAnimation().GetEnumerator());
        // foreach (GameObject obj in rootObjects) obj.SetActive(true);

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
