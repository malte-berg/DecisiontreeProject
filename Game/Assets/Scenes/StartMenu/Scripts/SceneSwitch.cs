using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour{

    int withCutscene = -1;
    public int WithCutscene{ set{ this.withCutscene = value; }}
    public bool hasSeenCutscene = false;

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

        //If the scene switches to the Combat scene...
        if (sceneIndex == 4){    //Scene 4 is Combat
            player.MusicToPlay = 0; //Play Combat music track
            //Before Slums Boss
            if (player.CombatsWon == 10){
                withCutscene = 3;
                hasSeenCutscene = true;
            }
        }

        //If the scene switches to the InGameMenu scene...
        if (sceneIndex == 1){
            //If the player is in Area 1 (The Slums)
            if (player.CurrentAreaIndex == 1){
                player.MusicToPlay = 0; //Play Slums main theme
                
                //After Slums Boss
                if (player.CombatsWon == 11){
                    withCutscene = 2;
                    hasSeenCutscene = true;
                }
            }

            //If the player is in Area 2 (Commoner's Quarters)
            else if (player.CurrentAreaIndex == 2){
                player.MusicToPlay = 1; //Play Commoner's Quarters main theme
            }

            //If the player is in Area 3 (Highest Heaven)
            else if (player.CurrentAreaIndex == 3){
                player.MusicToPlay = 2; //Play Highest Heaven main theme
            }
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
