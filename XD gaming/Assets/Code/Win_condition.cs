using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_condition : MonoBehaviour {
    public int nextScene;
    AudioSource winSound;

    // Start is called before the first frame update
    void Start(){
        winSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) {
            winSound.Play();
            SceneManager.LoadScene(nextScene);
        }
    }
}
