using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = SettingsManager.instance.volume;
    }
}
