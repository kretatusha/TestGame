using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float masterValue;

    void Start()
    {
        masterValue = PlayerPrefs.GetFloat("Volume");
        audioMixer.SetFloat("Volume",masterValue);
    }

    public void MasterVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}