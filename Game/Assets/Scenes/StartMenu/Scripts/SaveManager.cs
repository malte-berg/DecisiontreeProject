using UnityEngine;

public class SaveManager : MonoBehaviour{

    public void CreateSave(Player player){

        Save s = player.CreateSave();
        string json = JsonUtility.ToJson(s, true);
        print($"JSON_DATA:\n{json}");

    }

}