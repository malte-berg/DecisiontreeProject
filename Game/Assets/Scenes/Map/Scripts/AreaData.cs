using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaData", menuName = "Game/AreaData")]
public class AreaData : ScriptableObject
{
    public int areaIndex;
    public string areaName;
    public Sprite backgroundImage;
    public AudioClip bgm;

    [SerializeField] // 
    private Boolean unlock; 
    private Item[] shelfItems; // items that can be sold according to the corresponding area

    public Item[] ShelfItems{ get{ return shelfItems; } set{ this.shelfItems = value;}}

    public Boolean Unlock{ get{ return unlock; } set{ this.unlock = value;}}

}