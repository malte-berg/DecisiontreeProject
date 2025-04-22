using System;
using System.IO;
using UnityEngine;

public class SaveManager {

    public void CreateSave(Player player){

        Save s = player.CreateSave();
        string json = JsonUtility.ToJson(s, true);
        File.WriteAllText($"Saves/{DateTime.Now.ToString("yyyyMMddHHmmss")}.json", json);

    }

    public Save ReadSave(string name){

        string path = $"Saves/{name}";

        if (File.Exists(path)) {

            string content = File.ReadAllText(path);
            return JsonUtility.FromJson<Save>(content);

        } else {

            Debug.LogError($"File not found! {name}");
            return null;

        }

    }

}