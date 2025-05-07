using UnityEngine.UI;
using UnityEngine;

public class Backgrounds : MonoBehaviour{

    Sprite[] sprites;
    GameObject BGGO;
    Image BGI;

    public void Init(Sprite[] backgrounds){

        BGGO = gameObject;
        BGGO.SetActive(false);
        BGI = BGGO.GetComponent<Image>();
        sprites = backgrounds;

    }

    public void SetBG(int index){

        if(index < 0 || index >= sprites.Length){

            Debug.LogError("BG NOT FOUND");
            return;

        }

        BGI.sprite = sprites[index];
        BGGO.SetActive(true);

    }

    public void Hide(){

        BGGO.SetActive(false);

    }

}