using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalk
{
    float speed = 0.05f;

    public  StateWalk(GameObject obj)
    {
        Debug.Log("Walk");
        obj.transform.Translate(Vector3.forward * speed);
        AnimatorStateInfo state = obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0); 
        if (!state.IsName("Walk"))
        {
            obj.GetComponent<Animator>().Play("Walk");
        }
    }
}
