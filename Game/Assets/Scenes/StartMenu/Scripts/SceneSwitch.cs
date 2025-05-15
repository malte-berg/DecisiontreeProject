using System.Collections;
using System.Collections.Generic;
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
            foreach(StatusEffect s in player.statusEffects) {
                while(s.Turns > 0) {
                    s.DecrementEffect();
                }
            }

        //  COMBAT SCENE
        if (sceneIndex == 4){    //Scene 4 is Combat
            player.MusicToPlay = 0; //Play Combat music track
            //Before Slums Boss
            if (player.CombatsWon == 10 && player.CurrentAreaIndex == 1){
                withCutscene = 2;   //Before Slums Boss
            }

            else if (player.CombatsWon == 10 && player.CurrentAreaIndex == 3){
                withCutscene = 7;   //Before End Boss Starts
            }
        }

        //  IN-GAME-MENU SCENE
        if (sceneIndex == 1){
            //If the player is in Area 1 (The Slums)
            if (player.CurrentAreaIndex == 1){
                player.MusicToPlay = 0; //Play Slums main theme
                
                if (player.CombatsWon == 11 && player.hasSeenCutscene[0] == false){
                    withCutscene = 3;   //After Slums Boss
                    player.hasSeenCutscene[0] = true;   //Makes sure this cutscene does not appear every time you go into the "InGameMenu" scene (from any other scene)... (Kinda scuffed but the Expo is soon)
                }
            }

            //If the player is in Area 2 (Commoner's Quarters)
            else if (player.CurrentAreaIndex == 2){
                player.MusicToPlay = 1; //Play Commoner's Quarters main theme

                if (player.CombatsWon == 10 && player.hasSeenCutscene[1] == false){
                    withCutscene = 4;   //Before Comm Quarts Boss
                    player.hasSeenCutscene[1] = true;
                }

                else if (player.CombatsWon == 11 && player.hasSeenCutscene[2] == false){
                    withCutscene = 5; //After Comm Quarts Boss
                    player.hasSeenCutscene[2] = true;
                }
            }

            //If the player is in Area 3 (Highest Heaven)
            else if (player.CurrentAreaIndex == 3){
                player.MusicToPlay = 2; //Play Highest Heaven main theme

                if (player.CombatsWon == 10 && player.hasSeenCutscene[3] == false){
                    withCutscene = 6;   //Before High Heav Boss
                    player.hasSeenCutscene[3] = true;
                }

                else if (player.CombatsWon == 11 && player.hasSeenCutscene[4] == false){
                    withCutscene = 8;   //End Cutscene
                    player.hasSeenCutscene[4] = true;
                }
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
