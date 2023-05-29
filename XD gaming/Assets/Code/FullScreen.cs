using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown dropdown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start(){
        toggle.isOn = Screen.fullScreen?true:false;
        CheckResolution();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void EnableFullScreen(bool fullScreen){
        Screen.fullScreen = fullScreen;
    }

    public void CheckResolution(){
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                actualResolution = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = actualResolution;
        dropdown.RefreshShownValue();
        dropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void ChangeResolution(int resIndex){

        PlayerPrefs.SetInt("numeroResolucion", dropdown.value);
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
