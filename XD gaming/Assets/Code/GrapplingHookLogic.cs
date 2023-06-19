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
        public float airBoost = 1;

        [Header("Layer Mask")]
        public LayerMask whatIsGrappeable;

        [Header("Objetos")]
        public Transform gunTip;
        public Transform cam;
        public Transform player;
        public Camera camCamera;


        private LineRenderer lr;
        private Transform anchor;
        private SpringJoint joint;
        private Vector3 grapplingPoint = new(0, 0, 0);
        private float distance;
        private bool movil;
        private float defaultAirMultiplier;
        private bool zoomOut = true;
        private AudioSource grappleSound;

        public PlayerController pl;
        bool hookDeplyed;


        void Start() {
            lr = GetComponent<LineRenderer>();
            defaultAirMultiplier = pl.getAirMultiplier();
            grappleSound = GetComponent<AudioSource>();
        }

        void Update() {
            //Debug.Log("Iñigo Montoya: " + ((Input.GetAxis("LT") > 0.5f || Input.GetAxis("RT") > 0.5f) && !hookDeplyed));
            float triggerInput = 0;
            bool triggerUsed = false;
            float rt = Input.GetAxis("RT");
            float lt = Input.GetAxis("LT");
            if (rt > 0 && !triggerUsed)
            {
                triggerInput = rt;
                triggerUsed = true;
            }
            else if (lt > 0 && !triggerUsed)
            {
                triggerInput = lt;
                triggerUsed = true;
            }
            if ( Input.GetKeyDown(KeyCode.Q) || (( triggerInput > 0.5f) && !hookDeplyed)){
                StartHook();
            }
            else if ( Input.GetKeyUp(KeyCode.Q) || ((triggerInput < 0.1f) && hookDeplyed))
            {
                StopHook();
            }
            //detiene el gancho al morir
            if (player.position.y <= -15) {
                StopHook();
            }

            if (zoomOut)
            {
                if (camCamera.fieldOfView > 75)
                {
                    camCamera.fieldOfView -= Time.deltaTime * 100f;
                }
                else
                {
                    camCamera.fieldOfView = 75;
                }
            }
            else {

                if (camCamera.fieldOfView < 95)
                {
                    camCamera.fieldOfView += Time.deltaTime * 100f;
                }
                else
                {
                    camCamera.fieldOfView = 95;
                }
            }
        }

        void LateUpdate() {
            DrawRope(movil);
        }

        void StartHook() {
            if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, maxDistance, whatIsGrappeable)) {
                hookDeplyed = true;
                grappleSound.Play();
                zoomOut = false;
                //camCamera.fieldOfView = Mathf.Lerp(95, 75, Time.deltaTime * 0.1f);
                //para objeto estatico
                grapplingPoint = hitInfo.point;
                //para objeto en movimiento
                anchor = hitInfo.transform;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.enablePreprocessing = false;
                joint.enableCollision = true;
                if (hitInfo.collider.CompareTag("MovablePlatform"))
                {
                    joint.connectedBody = hitInfo.rigidbody;
                    distance = Vector3.Distance(player.position, grapplingPoint);
                    movil = true;
                }
                else
                {
                    joint.connectedAnchor = grapplingPoint;
                    distance = Vector3.Distance(player.position, anchor.position);
                    movil = false;
                }


                joint.minDistance = distance * 0.25f;

                joint.spring = SpringForce;
                joint.damper = SpringDamper;
                joint.massScale = SpringMassScale;

                pl.setAirMultiplier(airBoost);

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
            zoomOut = true;
            hookDeplyed = false;
            //camCamera.fieldOfView = Mathf.Lerp(75, 95, Time.deltaTime * 0.1f);
            lr.positionCount = 0;
            Destroy(joint);
            pl.setAirMultiplier(defaultAirMultiplier);
        }

    }
}