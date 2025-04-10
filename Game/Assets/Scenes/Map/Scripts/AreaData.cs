using UnityEngine;

[CreateAssetMenu(fileName = "AreaData", menuName = "Game/AreaData")]
public class AreaData : ScriptableObject
{
    public int areaIndex;
    public string areaName;
    public Sprite backgroundImage;
    public AudioClip bgm;

    [SerializeField]
    Item[] shelfItems; // items that can be sold according to the corresponding area

    public Item[] ShelfItems{ get{ return shelfItems; } set{ this.shelfItems = value;}}

}