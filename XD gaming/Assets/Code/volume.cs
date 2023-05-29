using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;

    // Start is called before the first frame update
    void Start(){
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        GetOnMute();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void ChangeSlider(float valor){
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        GetOnMute();
    }

    public void GetOnMute(){
        imageMute.enabled = sliderValue == 0?true:false;
    }
}
