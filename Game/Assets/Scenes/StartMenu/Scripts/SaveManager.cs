using System;
using System.IO;
using UnityEngine;

public class SaveManager {

    public Save CreateSave(Player player){

        Save s = player.CreateSave();
        string json = JsonUtility.ToJson(s, true);
        DeleteOldSaves();
        File.WriteAllText($"Saves/{DateTime.Now.ToString("yyyyMMddHHmmss")}.json", json);
        return s;

    }

    void DeleteOldSaves(){

        DirectoryInfo directoryInfo = new DirectoryInfo("Saves");
        FileInfo[] files = directoryInfo.GetFiles("*.json");

        foreach(FileInfo file in files){

            try{

                file.Delete();

            } catch {}

        }

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