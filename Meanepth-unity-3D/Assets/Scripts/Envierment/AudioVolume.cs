using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    void Update()
    {
        if(SettingsManager.instance != null){
        GetComponent<AudioSource>().volume = SettingsManager.instance.volume;
        }
    }
}
