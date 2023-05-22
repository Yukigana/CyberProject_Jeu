using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private Toggle fullscreenToggle;

    private Resolution[] resolutions;
    private int currentResolutionID;

    private void Awake()
    {
        //init
        resolutionDropDown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> resolutionLabels = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            resolutionLabels.Add(resolutions[i].ToString());
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResolutionID = i;
        }

        resolutionDropDown.AddOptions(resolutionLabels);

        //Attribution des valeurs par défaut
        resolutionDropDown.value = currentResolutionID;
        fullscreenToggle.isOn = Screen.fullScreen;

        //Link les events 
        resolutionDropDown.onValueChanged.AddListener(UpdateResolution);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
    }

    private void UpdateResolution(int value)
    {
        currentResolutionID = value;
        Screen.SetResolution(resolutions[currentResolutionID].width, resolutions[currentResolutionID].height, Screen.fullScreen);
        print("Resolution ID : " + value);
    }

    private void ToggleFullscreen(bool value)
    {
        print("Fullscreen : " + value);
        Screen.fullScreen = value;
    }
}
