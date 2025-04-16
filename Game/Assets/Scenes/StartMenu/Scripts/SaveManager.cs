using UnityEngine;

public class SaveManager : MonoBehaviour{

    public void CreateSave(Player player){

        Save s = new Save(player);
        string json = JsonUtility.ToJson(s, true);
        print($"JSON_DATA:\n{json}");

    }

}