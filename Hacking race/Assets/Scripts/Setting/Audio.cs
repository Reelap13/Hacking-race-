using UnityEngine;

public class Audio
{
    static float musicVolume = 0;
    static float soundVolume = 0;

    static Audio()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        if (PlayerPrefs.HasKey("SoundVolume"))
            soundVolume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public float MusicVolume
    {
        set
        {
            musicVolume = value;
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        }
        get
        {
            return musicVolume;
        }
    }

    public float SoundVolume
    {
        set
        {
            soundVolume = value;
            PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        }
        get
        {
            return soundVolume;
        }
    }
}
