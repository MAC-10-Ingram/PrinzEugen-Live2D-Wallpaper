using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioSource player;
    public AudioClip[] clips;
    public GameObject On;
    public GameObject Off;
    private static bool mute;
    SettingDTO dto;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        Off.SetActive(false);
        dto = SettingDAO.LoadSetting();

        if (dto == null)
        {
            dto = new SettingDTO(false);
        }

        On.SetActive(!dto.getMute());
        Off.SetActive(dto.getMute());
        player.mute = dto.getMute();

    }

    public void muteButton() {

        On.SetActive(dto.getMute());
        Off.SetActive(!dto.getMute());
        player.mute = !dto.getMute();

        dto.setMute(!dto.getMute());
        SettingDAO.SaveSetting(dto);
    }

    public static void playSound(AudioClip clip) {
        player.Stop();
        player.clip = clip;
        player.time = 0;
        player.Play();
    }

    public static bool isPlaying() {
        return player.isPlaying;
    }
}
