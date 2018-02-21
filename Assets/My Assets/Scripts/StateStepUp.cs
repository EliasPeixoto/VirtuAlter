using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStepUp 
{
    float jumpForce = 100f;

    public StateStepUp (GameObject obj)
    {
        Debug.Log("StepUp");
        obj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }
   
}
