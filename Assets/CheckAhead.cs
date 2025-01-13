using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAhead : MonoBehaviour
{
    public ControlKart controlKart;
    public bool evading=false;

    private void OnTriggerEnter(Collider other)
    {
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("StopR"))
        {
            controlKart.IgnoreRotation(true);
            controlKart.Turn(1f);
        }
        if (other.gameObject.name.Contains("StopL"))
        {
            controlKart.IgnoreRotation(true);
            controlKart.Turn(-1f);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("StopL") || other.gameObject.name.Contains("StopR"))
        {
            controlKart.IgnoreRotation(false);
        }
    }
}
