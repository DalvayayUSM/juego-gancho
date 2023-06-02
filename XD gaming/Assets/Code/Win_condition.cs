using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_condition : MonoBehaviour
{
    public int nextScene;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    void Start(){
    }

    // Update is called once per frame
    void Update(){
        
    }
}
