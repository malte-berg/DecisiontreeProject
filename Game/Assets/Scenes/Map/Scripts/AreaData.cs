using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData")]
public class AreaData : ScriptableObject
{
    public int areaIndex;
    public string arealName;
    public Sprite backgroundImage;
    public AudioClip bgm;

    [SerializeField]
    Item[] shelfItems; // items that can be sold according to the corresponding area

    public Item[] ShelfItems{ get{ return shelfItems; } set{ this.shelfItems = value;}}

}
