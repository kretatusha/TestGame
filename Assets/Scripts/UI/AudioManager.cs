using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioMixer audioMixer;

    public static AudioManager instance;

    void Awake()
    {
        if (AudioManager.instance == null)
        {
            DontDestroyOnLoad(gameObject);
            AudioManager.instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        float music = PlayerPrefs.GetFloat("Volume", 0f);
        AdjustMusicVolume(music);
    }

    public void AdjustMusicVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

}
