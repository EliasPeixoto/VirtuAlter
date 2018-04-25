using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStepUp : MonoBehaviour
{
    

    public StateStepUp(GameObject obj)
    {
        Debug.Log("StepUp");
        AnimatorStateInfo state = obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0); 
        if (!state.IsName("Step"))
        {
            obj.GetComponent<Animator>().Play("Step");
        }
    }

}
