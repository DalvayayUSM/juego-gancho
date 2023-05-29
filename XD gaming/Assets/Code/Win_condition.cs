using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_condition : MonoBehaviour
{
    public TMP_Text winText;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            winText.SetText("You ganaste");
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player"))
        {
            winText.SetText("");
        }
    }
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        
    }
}
