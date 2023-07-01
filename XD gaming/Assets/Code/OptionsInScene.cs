using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsInScene : MonoBehaviour
{
    public GameObject optionsPanel;
    OptionsController optionsController;
    bool active;

    // Start is called before the first frame update
    void Start() {
        //optionsController = optionsPanel.FindGameObjectWithTag("Options").GetComponent<OptionsController>();
        optionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log(optionsPanel.activeInHierarchy);
            if (!active) {
            ShowOptions();
            }
            else {
                HideOptions();
            }
        }
    }

    public void ShowOptions(){
        active = true;
        optionsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void HideOptions(){
        active = false;
        optionsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
