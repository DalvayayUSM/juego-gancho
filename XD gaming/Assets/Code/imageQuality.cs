using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class imageQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;
    // Start is called before the first frame update
    void Start(){
        quality = PlayerPrefs.GetInt("numeroDeCalidad", 1);
        dropdown.value = quality;
        ChangeImageQuality();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void ChangeImageQuality(){
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }
}
