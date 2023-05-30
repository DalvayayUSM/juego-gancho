using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisableGrapple : MonoBehaviour
{
    [Header("Texto del gancho")]
    public TMP_Text grappleText;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            grappleText.SetText("Gancho: Desactivado");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            grappleText.SetText("Gancho: Disponible");
        }
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
