using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform firePoint;

    public float delay = 3;
    public float forceMultiplier = 3;
    float timer;
    GameObject ball;
    Rigidbody rb;

    void Start()
    {
        InvokeRepeating(nameof(createBall), delay, delay);

    }
    void createBall(){
        ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
        rb = ball.GetComponent<Rigidbody>();
        Invoke(nameof(fire),delay);
    }
    void fire(){
        
        rb.AddForce(Vector3.up*forceMultiplier, ForceMode.Impulse);
        Destroy(ball, delay);

        
    }
}
