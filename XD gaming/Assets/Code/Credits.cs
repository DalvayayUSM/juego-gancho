using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    [Header("Música épica")]
    public AudioSource musica;

    // Start is called before the first frame update
    void Start() {
        musica.volume = PlayerPrefs.GetFloat("volumenAudio", 0.125f);
        musica.Play();
        StartCoroutine(Waiter());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Waiter() {
        yield return new WaitForSeconds(35);
        Application.Quit();
    }
}
