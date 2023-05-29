using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brightness : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image brightnessPanel;
    // Start is called before the first frame update
    void Start(){
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, slider.value);
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void ChangeSlider(float valor){
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, slider.value);
    }
}
