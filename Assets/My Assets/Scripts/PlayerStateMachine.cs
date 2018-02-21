using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    State state;

    bool hasStep = false;

    enum State
    {
        Idle,
        Walk,
        StepUp,
        StepDown,
        IRightHigh,
        IRightLow,
        ILeftLow,
        ILeftHigh,
        IRightHighLeftHigh,
        IRightHighLeftLow,
        IRightLowLeftHigh,
        IRightLowLeftLow,
    };

    void Start()
    {
        state = State.Idle;
    }
	
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (State.Idle):
                if (Input.GetButton("StepUp") && hasStep)
                {
                    state = State.StepUp;
                }
                else
                {
                    if (Input.GetButton("Walk"))
                    {

                    }
                    else
                    {
                        if (Input.GetButton("RightHigh"))
                        {

                        }
                        else
                        {
                            if (Input.GetButton("RightLow"))
                            {

                            }
                            else
                            {
                                if (Input.GetButton("LeftHigh"))
                                {

                                }
                                else
                                {
                                    if (Input.GetButton("LeftLow"))
                                    {
                                    
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            case (State.Walk):
                if (!Input.GetButton("Walk"))
                {
                    
                }
                break;
        }
    }
}

   
