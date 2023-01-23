using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;
    public Slider volumeSlider;
    void Start()
    {
        ResolutionDropdown();
        LoadPlayerPrefs();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
    public void GraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("quality", index);
    }
    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, false);
        PlayerPrefs.SetInt("resolution", index);
    }
    public void ResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].ToString());

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void LoadPlayerPrefs()
    {
        SetVolume(PlayerPrefs.GetFloat("volume"));
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        GraphicsQuality(PlayerPrefs.GetInt("quality"));
        qualityDropdown.value = (PlayerPrefs.GetInt("quality"));
        SetResolution(PlayerPrefs.GetInt("resolution"));
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution");
    }
}
