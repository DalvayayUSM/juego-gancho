using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Grapple
{
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
        private Transform anchor;
        private SpringJoint joint;
        private Vector3 grapplingPoint = new(0, 0, 0);
        private float distance;
        private bool movil;


        void Start()
        {
            lr = GetComponent<LineRenderer>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire2")) {
                StartHook();
            }
            else if (Input.GetButtonUp("Fire2")) {
                StopHook();
            }
            //detiene el gancho al morir
            if (player.position.y <= -6.15) {
                StopHook();
            }
        }

        void LateUpdate()
        {
            DrawRope(movil);
        }

        void StartHook()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(cam.position, cam.forward, out hitInfo, maxDistance, whatIsGrappeable))
            {
                //para objeto estatico
                grapplingPoint = hitInfo.point;
                //para objeto en movimiento
                anchor = hitInfo.transform;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                if (hitInfo.collider.CompareTag("MovablePlatform")) {
                    joint.connectedBody = hitInfo.rigidbody;
                    movil = true;
                }
                else
                {
                    joint.connectedAnchor = grapplingPoint;
                    movil = false;
                }

                //distance = Vector3.Distance(player.position, grapplingPoint);
                joint.minDistance = distance * 0.25f;

                joint.spring = SpringForce;
                joint.damper = SpringDamper;
                joint.massScale = SpringMassScale;

                lr.positionCount = 2;
            }
        }

        void DrawRope(bool flag) {
            if (!joint || anchor == null) return;
            lr.SetPosition(0, gunTip.position);
            //distingue entre punto en movimiento o estatico
            if (flag) {
            lr.SetPosition(1, anchor.position);
            }
            else {
                lr.SetPosition(1, grapplingPoint);
            }
        }

        void StopHook() {
            lr.positionCount = 0;
            Destroy(joint);
        }

    }
}