using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour{

    public GameObject dialogueBoxGO;
    public GameObject backgroundGO;
    public Sprite[] backgrounds;
    public SceneScript[] sceneScripts;
    GameObject canvas;
    DialogueBox db;
    int currCutscene;

    public void SwitchScene(int from, int to, int cutscene){

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        AsyncOperation departingOp = SceneManager.UnloadSceneAsync(from);
        StartCoroutine(DoCutscene(departingOp, to, cutscene));
        new SaveManager().CreateSave(GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>());

    }

    public void SkipCutscene(){
        if (!sceneScripts[currCutscene].skipping) sceneScripts[currCutscene].skipping = true;
        db.SkipDialogue();
    }

    IEnumerator DoCutscene(AsyncOperation from, int to, int cutscene){

        currCutscene = cutscene;

        while(!from.isDone)
            yield return null;

        AsyncOperation arrivingSceneOp = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        arrivingSceneOp.allowSceneActivation = false;

        if(cutscene >= 0 && cutscene < sceneScripts.Length) {

            sceneScripts[currCutscene].skipping = false;

            if(canvas == null) canvas = GameObject.FindGameObjectWithTag("Canvas");
            Backgrounds bg = Instantiate(backgroundGO, canvas.transform).GetComponent<Backgrounds>();
            bg.Init(backgrounds);
            db = Instantiate(dialogueBoxGO, canvas.transform).GetComponent<DialogueBox>();
            db.Init(sceneScripts[cutscene]);
            sceneScripts[cutscene].LoadCutscene(db, bg);
            GameObject.FindGameObjectWithTag("Skip").GetComponent<RectTransform>().SetAsLastSibling();
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
