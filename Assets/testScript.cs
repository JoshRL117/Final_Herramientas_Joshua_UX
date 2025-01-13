using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    public GameObject box;
    public ArcadeKart arcadeKart;
    public float turnAngle;
    int passedFrames=0;
    int totalFrames=4;

    bool acc=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Invoke("Disable",3f);
    }
    
    void Disable()
    {
        box.SetActive(false);
    }

    public void Stop()
    {
        acc = false;
    }

    public void Advance()
    {
        acc = true;
    }

    public void turn(float turnAnglee)
    {
        turnAngle=turnAnglee;
    }

    // Update is called once per frame
    void Update()
    {
        //box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, box.transform.position.z + 1);
        //rb.AddForce(transform.forward*speed, ForceMode.Force);
        passedFrames++;
        if (passedFrames > totalFrames) 
        {
            passedFrames = 0;
            arcadeKart.MoveVehicle(acc, false, turnAngle);
        }
        else
        {
            arcadeKart.MoveVehicle(acc, false, 0);
        }
        
    }
}
