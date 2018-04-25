using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStepDown
{
    

    public StateStepDown(GameObject obj, float acceleration)
    {
        obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * acceleration, ForceMode.Acceleration);

    }
}
