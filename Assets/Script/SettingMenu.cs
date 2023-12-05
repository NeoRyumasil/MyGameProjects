using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;                   // Volume Slider
    [SerializeField] Toggle ScreenToggle;                   // Fullscreen Toggler
    [SerializeField] Dropdown ResDrop;                      // Resolution Dropdown

    //---------- Relosution Variable ----------\\
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float CurrentResfreshRate;
    private int CurrentResolutionIndex = 0;

     void Start()
    {
        //---------- Volume Set ----------\\
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        else
        {
            Load();
        }

        //---------- Resolution Set ----------\\
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        ResDrop.ClearOptions();
        CurrentResfreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == CurrentResfreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOptions = filteredResolutions[i].width + "x" + filteredResolutions[i].height;
            options.Add(resolutionOptions);

            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        ResDrop.AddOptions(options);
        ResDrop.value = CurrentResolutionIndex;
        ResDrop.RefreshShownValue();
    }


    public void VolumeMeter()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void ScreenChanger()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Changed!");
    }

    public void ResolutionToggle(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
