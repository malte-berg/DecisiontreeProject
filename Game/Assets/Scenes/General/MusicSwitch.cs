using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public AudioClip[] musicTracks;
    [Range(0,1)] public float volume = 1;
    private Player player;

    public void Start()
    {
        //Get the "Audio Source" component of the "Player" object.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        AudioSource playerMusic = player.gameObject.GetComponent<AudioSource>();

        //If the music source "whichMusic" is NOT the "Audio Resource" object for the "Audio Source" component of the "Player" object, then...
        //...change it to "whichMusic".
        if (playerMusic.clip != musicTracks[player.MusicToPlay] && musicTracks[player.MusicToPlay]){
            playerMusic.clip = musicTracks[player.MusicToPlay];
            playerMusic.volume = volume;
            playerMusic.Play();
        }
    }
}
