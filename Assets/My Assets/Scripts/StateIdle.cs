using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle
{
    public StateIdle(GameObject obj)
    {
        
        AnimatorStateInfo state = obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0); 
        if (!state.IsName("Idle"))
        {
            obj.GetComponent<Animator>().Play("Idle");
        }
    }
}
