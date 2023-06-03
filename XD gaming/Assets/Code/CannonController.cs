using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject ballPrefab;
    public Transform firePoint;

    [Header("Values")]
    public float delay = 3;
    public float forceMultiplier = 3;
    GameObject ball;
    Rigidbody rb;

    void Start() {
        InvokeRepeating(nameof(CreateBall), delay, delay);

    }
    void CreateBall(){
        ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
        rb = ball.GetComponent<Rigidbody>();
        Invoke(nameof(Fire),delay);
    }
    void Fire(){
        rb.AddForce(firePoint.up*forceMultiplier, ForceMode.Impulse);
        Destroy(ball, delay*1.5f);

        
    }
}
