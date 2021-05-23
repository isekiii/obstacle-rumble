using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsScript : MonoBehaviour
{
    
    public AudioMixer musicMixer, sfxMixer;
    
    
    public TMP_Dropdown RezDropdown;
    public TMP_Dropdown quality;

    private Resolution[] resolutions;

    public Slider musicVolume;
    public Slider soundEffects;
    public Toggle fullscreenBox;
    
    void Start()
    {
        RezDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        var rezList = new List<string>();
        foreach (Resolution rez in resolutions)
        {
            string r = $"{rez.width}x{rez.height} {rez.refreshRate}hz";
            rezList.Add(r);
        }

        RezDropdown.AddOptions(rezList);
        
        SetValues();
        
    }

    public void Apply()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    public void SetValues()
    {
        if (PlayerPrefs.GetInt("Fullscreen") == 1)
        {
            SetFullscreen(true);
        }
        else SetFullscreen(false);
        musicVolume.value =  PlayerPrefs.GetFloat("Volume") ;
        soundEffects.value =  PlayerPrefs.GetFloat("soundEffects")  ;
        quality.value = PlayerPrefs.GetInt("qualityIndex");
        RezDropdown.value = PlayerPrefs.GetInt("resolutionIndex");
    }
    
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        musicMixer.SetFloat("Volume",Mathf.Log10(volume) * 20 );
       
    }

    public void SetsoundEffects(float volume)
    {
        PlayerPrefs.SetFloat("soundEffects", volume);
        sfxMixer.SetFloat("Volume", Mathf.Log10(volume) * 20 );
    }
    

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else PlayerPrefs.SetInt("Fullscreen", 0);
        
        Screen.fullScreen = isFullscreen;
    }

    public void Resetgame()
    {
        PlayerPrefs.SetString("BestName1","");
        PlayerPrefs.SetString("BestName2","");
        PlayerPrefs.SetString("BestName3","");
        PlayerPrefs.SetInt("BestScore1",-100);
        PlayerPrefs.SetInt("BestScore2",-102);
        PlayerPrefs.SetInt("BestScore3",-103);
    }
    
}
