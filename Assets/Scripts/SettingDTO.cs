using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingDTO
{
    bool mute;
    float volume;
    private const float limitVol = -50.0f;
    private const float minVol = -80f;

    public SettingDTO(){
        this.mute = false;
        this.volume = 1.0f;
    }

    public SettingDTO(bool mute, float volume) {
        this.mute = mute;
        this.volume = volume;
    }

    public bool getMute() { return mute; }

    public void setMute(bool m) { this.mute = m; }

    public float getVolume() { return volume; }

    public void setVolume(float v) { 
        this.volume = v;
        if(this.volume <= limitVol){
            this.volume = minVol;
        }
    }
}
