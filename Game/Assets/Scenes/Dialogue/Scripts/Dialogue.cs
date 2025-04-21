using UnityEngine;

//Lets you edit the public variable values in the Unity editor.
[System.Serializable]   
public class Dialogue
{
    public string name;

    [TextArea(3, 20)]
    public string[] sentences;
}
