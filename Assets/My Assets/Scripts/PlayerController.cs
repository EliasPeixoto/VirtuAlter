using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetButton("LeftLow"))
        {
            GetComponent<StateMachine>().leftLow = true;
        }
        else
        {
            GetComponent<StateMachine>().leftLow = false;
        }

        if (Input.GetButton("LeftHigh"))
        {
            GetComponent<StateMachine>().leftHigh = true;
        }
        else
        {
            GetComponent<StateMachine>().leftHigh = false;
        }

        if (Input.GetButton("RightLow"))
        {
            GetComponent<StateMachine>().rightLow = true;
        }
        else
        {
            GetComponent<StateMachine>().rightLow = false;
        }

        if (Input.GetButton("RightHigh"))
        {
            GetComponent<StateMachine>().rightHigh = true;
        }
        else
        {
            GetComponent<StateMachine>().rightHigh = false;
        }

        if (Input.GetButton("StepUp"))
        {
            GetComponent<StateMachine>().stepUp = true;
        }
        else
        {
            GetComponent<StateMachine>().stepUp = false;
        }

        if (Input.GetButtonUp("StepUp"))
        {
            GetComponent<StateMachine>().stepDown = true;
        }
        else
        {
            GetComponent<StateMachine>().stepDown = false;
        }
    }
}
