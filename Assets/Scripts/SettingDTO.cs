using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingDTO
{
    bool mute;

    public SettingDTO(bool mute) {
        this.mute = mute;
    }

    public bool getMute() { return mute; }

    public void setMute(bool m) { this.mute = m; }
}
