using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeLauncher : MonoBehaviour
{

    public Rigidbody granada;
    private float velocidad = 10.0f;
    private GameObject[] pelotas;
    private float nPelotas;
    private Vector3 gravedad = new Vector3(0, -9.8f, 0);
    private int aux = 0;
    private LineRenderer lr;

    Vector3 mru(float time, Vector3 pos0){
        float posX = pos0.x + velocidad*time + gravedad.x*time/2;
        float posY = pos0.y + velocidad*time + gravedad.y*time/2;
        float posZ = pos0.z + velocidad*time + gravedad.z*time/2;
        return new Vector3(posX, posY, posZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        while(aux < 100){
            lr.positionCount = 100;
            lr.SetPosition(aux, mru(aux, transform.position));
            aux += 1;
        }

        if(Input.GetKeyDown("space")){

            Rigidbody clon;
            clon = Instantiate(granada, transform.position, transform.rotation);

            clon.velocity = transform.TransformDirection(new Vector3(0,Input.GetAxis("Vertical"),0)*velocidad);
            
            
        }    
    }
}
