using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
public class SettingController : MonoBehaviour
{

    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] Toggle fullScreenToggle;

    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;

    [SerializeField] UnityEngine.GameObject MainMenu;
    [SerializeField] UnityEngine.GameObject SettingMenu;

    Resolution[] resolutions;

    int difficultyIndex;
    void Start()
    {
        compilationOfResolutionDropdown();
        LoadSetting();
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }




    public void SetMusicsVolume(float volume)
    {
        Debug.Log(volume);
        mixer.audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundsVolume(float volume)
    {
        mixer.audioMixer.SetFloat("SoundVolume", volume);
    }


    public void ExitSetting()
    {
        ReturnSetting();
        LoadSetting();
        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }

    public void SaveSetting()
    {
        Setting.Screen.ResolutionIndex = resolutionDropdown.value;
        Setting.Screen.IsFullScreen = fullScreenToggle.isOn;

        float audioValue;
        mixer.audioMixer.GetFloat("MusicVolume", out audioValue);
        Setting.Audio.MusicVolume = audioValue;

        mixer.audioMixer.GetFloat("SoundVolume", out audioValue);
        Setting.Audio.SoundVolume = audioValue;
    }


    void LoadSetting()
    {
        resolutionDropdown.value = Setting.Screen.ResolutionIndex;
        fullScreenToggle.isOn = Setting.Screen.IsFullScreen;

        musicSlider.value = Setting.Audio.MusicVolume;
        soundSlider.value = Setting.Audio.SoundVolume;
    }

    void ReturnSetting()
    {
        Screen.SetResolution(Setting.Screen.Resolution.width, Setting.Screen.Resolution.height, Setting.Screen.IsFullScreen);

        mixer.audioMixer.SetFloat("MusicVolume", Setting.Audio.MusicVolume);
        mixer.audioMixer.SetFloat("SoundVolume", Setting.Audio.SoundVolume);
    }

    void compilationOfResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

    }

}
