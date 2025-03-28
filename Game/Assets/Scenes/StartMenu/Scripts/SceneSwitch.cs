using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
