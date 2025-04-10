using UnityEngine;

public class Map : MonoBehaviour
{

    Player player;
    public int MaxlevelIntex;

    private void Awake() {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }
}
