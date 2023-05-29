using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrapplingHookLogic : MonoBehaviour
{
    [Header("Propiedades fisicas del gancho")]
    public float SpringForce = 5.0f;
    public float SpringDamper = 7.0f;
    public float SpringMassScale = 4.5f;
    public float maxDistance = 30;

    [Header("Layer Mask")]
    public LayerMask whatIsGrappeable;

    [Header("Objetos")]
    public Transform gunTip;
    public Transform cam;
    public Transform player;


    private LineRenderer lr;
    private SpringJoint joint;
    private Vector3 grapplingPoint = new(0,0,0);
    private float distance;

    
    void Start(){
        lr = GetComponent<LineRenderer>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Q)){
            StartHook();
        }
        else if(Input.GetKeyUp(KeyCode.Q)){
            StopHook();
        }
    }

    void LateUpdate(){
        DrawRope();
    }

    void StartHook() {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.position, cam.forward ,out hitInfo, maxDistance,whatIsGrappeable)){
            grapplingPoint = hitInfo.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplingPoint;

            distance = Vector3.Distance(player.position, grapplingPoint);
            joint.minDistance = distance * 0.25f;

            joint.spring = SpringForce;
            joint.damper = SpringDamper;
            joint.massScale = SpringMassScale;

            lr.positionCount = 2;
        }
    }

    void DrawRope(){
        if (!joint) return;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplingPoint);
    }

    void StopHook(){
        lr.positionCount = 0;
        Destroy(joint);
    }

}
