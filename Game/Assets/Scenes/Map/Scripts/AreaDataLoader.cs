using UnityEngine;
public static class AreaDataLoader
{
    public static AreaData Load(string fileName)
    {
        AreaData currentLevelData = Resources.Load<AreaData>($"LevelData/{fileName}");
        if (currentLevelData != null)
        {
            Debug.Log("Load:" + currentLevelData.areaName);
            return currentLevelData;
        }
        else
        {
            Debug.LogError("Not found: " + fileName);
            return null;
        }
    }
}
