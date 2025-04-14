using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour{

    void Start(){

        EndCutscene();

    }

    void EndCutscene(){

        SceneManager.UnloadSceneAsync("Cutscene");

    }
    
}
