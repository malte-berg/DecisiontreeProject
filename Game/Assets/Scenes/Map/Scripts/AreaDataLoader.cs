using System;
using UnityEngine;
public static class AreaDataLoader
{
    public static AreaData Load(int areaIntex)
    {
        string fileName = "Area"+areaIntex;
        AreaData currentLevelData = Resources.Load<AreaData>($"LevelData/{fileName}");
        if (currentLevelData != null)
        {
            //Debug.Log("Load:" + currentLevelData.areaName);
            return currentLevelData;
        }
        else
        {
            Debug.LogError("Not found: " + fileName);
            return null;
        }
    }

    public static Boolean IsAreaExplored(int areaIntex)
    {
        AreaData a = Load(areaIntex);
        if (a.Unlock == false)
        {
            return false;
        }
        return true;
    }

    public static void MovePlayerToArea(Player player, int areaIndex)
    {
         
        if (!IsAreaExplored(areaIndex))
        {
            Debug.Log("Progress mismatch");
            return;
        } else if (player.CurrentAreaIndex == areaIndex)
        {
            return;
        }

        player.CurrentAreaIndex = areaIndex;
    }

    public static Item[] GetAreaItems(int areaIndex)
    {
        if(areaIndex < 1) areaIndex = 1;
        return Load(areaIndex).RegionItems;
    }
    public static void InitAreaRegionItems(int areaIndex, Item[] regionItems)
    {
            Load(areaIndex).RegionItems = regionItems; 
    }
}
