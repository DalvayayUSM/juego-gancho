using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensibility : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    // Start is called before the first frame update
    void Start() {
        slider.value = PlayerPrefs.GetFloat("sensibilidad", 0.5f);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("sensibilidad", sliderValue);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
