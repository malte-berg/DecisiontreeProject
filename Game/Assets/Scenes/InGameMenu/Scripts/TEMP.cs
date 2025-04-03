using UnityEngine;

public class TEMP : MonoBehaviour{

    void Awake() {
        
        Player player = GameObject.Find("Player").GetComponent<Player>(); // bad practice
        player.HidePlayer();

    }

}
