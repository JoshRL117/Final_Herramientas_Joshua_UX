using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CheckSides : MonoBehaviour
{

    public ControlKart controlKart;
    public CheckAhead checkAhead;
    public bool rightSide;
    public float rotationPer=0.3f;

    private void OnTriggerEnter(Collider other)
    {
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("ModularTrackStraight") || other.gameObject.name.Contains("ModularTrackCurveLarge"))
        {
            if (!checkAhead.evading)
            {
                if (rightSide)
                {
                    controlKart.Turn(-rotationPer);
                    Debug.Log("going left");
                }
                else
                {
                    controlKart.Turn(rotationPer);
                    Debug.Log("going right");
                }
            }            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
