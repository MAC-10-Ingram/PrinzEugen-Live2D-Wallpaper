using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioSource[] player;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponents<AudioSource>();
    }

    public static void playSound(AudioClip clip) {

        for(int i = 0; i < player.Length; i++){
            player[i].Stop();
            player[i].clip = clip;
            player[i].time = 0;
        }

        for(int i = 0; i < player.Length; i++){
            player[i].Play();
        }
    }

    public static bool isPlaying() {
        return player[0].isPlaying;
    }
}
