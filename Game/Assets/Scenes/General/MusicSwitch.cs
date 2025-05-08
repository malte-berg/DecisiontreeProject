using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public AudioClip musicToPlay;
    private AudioSource playerMusic;

    //For each scene with a "MusicManager" in it, this function is called.
    public void Start()
    {
        //Get the "Audio Source" component of the "Player" object.
        playerMusic = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();

        //If the music source "whichMusic" is NOT the "Audio Resource" object for the "Audio Source" component of the "Player" object, then...
        //...change it to "whichMusic".
        if (playerMusic.clip != musicToPlay){
            playerMusic.clip = musicToPlay;
        }

    }
}
