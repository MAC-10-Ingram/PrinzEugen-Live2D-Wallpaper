using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SettingDAO
{
    public static void SaveSetting(SettingDTO dto) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Setting.wp";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, dto);
        stream.Close();
    }

    public static SettingDTO LoadSetting()
    {
        string path = Application.persistentDataPath + "/Setting.wp";
        if (File.Exists(path))
        {
            FileStream stream = null;
            try
            {
                Debug.LogError("Loading file");
                BinaryFormatter formatter = new BinaryFormatter();
                stream = new FileStream(path, FileMode.Open);
                SettingDTO dto = formatter.Deserialize(stream) as SettingDTO;
                Debug.LogError("Loading result/ volume =  "+dto.getVolume());
                stream.Close();
                return dto;
            }
            catch (Exception e)
            {
                Debug.LogError("Loading error : " + e.StackTrace);
                stream.Close();
                File.Delete(path);
                return new SettingDTO();
            }
            
        }
        else {
            Debug.LogError("Setting file not found at "+path);
            return new SettingDTO();
        }

    }
}
