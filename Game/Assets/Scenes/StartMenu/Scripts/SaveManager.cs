using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour{

    public void CreateSave(Player player){

        Save s = player.CreateSave();
        string json = JsonUtility.ToJson(s, true);
        print($"JSON_DATA:\n{json}");
        File.WriteAllText($"Saves/{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt", json); // TODO json

    }

    public Save ReadSave(string name){

        string path = $"Saves/{name}.txt"; // TODO json

        if (File.Exists(path)) {

            string content = File.ReadAllText(path);
            return JsonUtility.FromJson<Save>(content);

        } else {

            Debug.LogError("File not found!");
            return null;

        }

    }

}