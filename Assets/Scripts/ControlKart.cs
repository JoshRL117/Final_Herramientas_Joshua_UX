using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ControlKart : MonoBehaviour
{
    Rigidbody rb;
    float maxspeed = 5f;
    public GameObject rayRight;
    public GameObject rayLeft;
    public float rotatespeed=0.8f;
    bool ignoreRotation = false;
    public float permitedAngle = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //rb= GetComponent<Rigidbody>();
        Invoke("EnableXFreeze", 0.2f);
    }

    private void EnableXFreeze()
    {
        // rb.constraints = rb.constraints | RigidbodyConstraints.FreezeRotationX;
    }

    public void IgnoreRotation(bool state)
    {
        ignoreRotation = state;
    }

    private void FixedUpdate()
    {
        transform.localPosition += transform.forward * 0.1f;
        ShootRay();
    }

    void ShootRay()
    {
        RaycastHit hitR;
        float distanceR=0;
        // Shoots ray from object's position in object's forward direction
        if (Physics.Raycast(rayRight.transform.position, rayRight.transform.forward, out hitR))
        {
            // Get the distance to the hit point
            distanceR = hitR.distance;

            // Get the hit object
            GameObject hitObject = hitR.collider.gameObject;

            //Debug.Log($"Hit {hitObject.name} at distance: {distanceR}");
        }

        RaycastHit hitL;
        float distanceL=0;
        // Shoots ray from object's position in object's forward direction
        if (Physics.Raycast(rayLeft.transform.position, rayLeft.transform.forward, out hitL))
        {
            // Get the distance to the hit point
            distanceL = hitL.distance;

            // Get the hit object
            GameObject hitObject = hitL.collider.gameObject;

            //Debug.Log($"Hit {hitObject.name} at distance: {distanceL}");
        }
        if (!ignoreRotation)
        {
            float diff = distanceR - distanceL;
            Debug.Log(diff);
            if (diff > permitedAngle || diff < -permitedAngle)
            {
                Debug.Log("entre");
                if (diff < 0)
                {
                    Turn(-rotatespeed);
                }
                else
                {
                    Turn(rotatespeed);
                }
            }
        }
        
    }


    public void Turn(float direction)
    {
        transform.Rotate(Vector3.up, direction);
    }
}
