using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour{

    int withCutscene = -1;
    public int WithCutscene{ set{ this.withCutscene = value; }}

    // A check to see if we need to go to title screen
    void Awake(){

        if(SceneManager.GetActiveScene().buildIndex == 0)
            return;

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if(p == null)
            LoadScene(0);
        
    }

    public void SwitchScene(int sceneIndex){

        Player player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();

        if(sceneIndex != 4 && sceneIndex != 3)
            player.HidePlayer();

        if (sceneIndex == 4){    //Scene 4 is Combat
            //If the player has won 10 battles in Area 1...
            if (player.CombatsWon == 10)
                //Play cutscene nr. 3 next.
                withCutscene = 3; //In Cutscene scene, "Slumsboss" cutscene is set as "Scene Scripts" nr. 3.
        }

        StartCoroutine(LoadScene(sceneIndex, withCutscene));

    }

    public IEnumerator LoadScene(int sceneIndex, int cutscene = -1) {

        // Add cutscene and next scene to load queue
        int from = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation csOp = SceneManager.LoadSceneAsync(10, LoadSceneMode.Additive);

        while(!csOp.isDone)
            yield return null;

        Scene cs = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(cs);
        GameObject[] GOs = cs.GetRootGameObjects();
        CutsceneManager CM = GOs[1].GetComponent<CutsceneManager>();
        CM.SwitchScene(from, sceneIndex, cutscene);

    }

}
