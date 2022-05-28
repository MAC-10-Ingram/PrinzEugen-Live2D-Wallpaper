using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private SettingDTO dto;
    private string voice = "Voice";
    public Slider slider;
    public AudioMixer master;
     
    // Start is called before the first frame update
    void Start()
    {
        dto = SettingDAO.LoadSetting();
        master.SetFloat(voice, dto.getVolume());
        slider.value = dto.getVolume();
    }

    // Update is called once per frame
    public void onVolumeChanged(){
        dto.setVolume(slider.value);
        SettingDAO.SaveSetting(dto);
        master.SetFloat(voice, dto.getVolume());
    }
}
