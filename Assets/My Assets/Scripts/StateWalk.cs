using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalk 
{
    float speed = 0.05f;

    public  StateWalk (GameObject obj)
    {
        Debug.Log("Walk");
       obj.transform.Translate(Vector3.forward * speed);
    }
}
