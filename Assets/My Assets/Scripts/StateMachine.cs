using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    public float acceleration = 85;
    public float jumpForce = 200;
        
    public bool isWalking = false;
    public bool idle = false;
    public bool rightLow = false;
    public bool rightHigh = false;
    public bool leftLow = false;
    public bool leftHigh = false;
    public bool stepUp = false;
    public bool stepDown = false;
    public bool hasFloor = false;
    public bool hasFall = false;
    public bool hasStep = false;

    void Update()
    {
        Machine();
    }

    IEnumerator DelayTranslate(float seconds)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 10);
        yield return new WaitForSeconds(seconds);
        transform.Translate(Vector3.forward * 1);

    }

    IEnumerator DelayIdle(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        idle = false;
    }

   
    void Machine()
    {
        if (!idle)
        {
            if (isWalking)
            {
                StateWalk Walk = new StateWalk(this.gameObject);
            }
            else
            {
                Debug.Log("Idle");
                StateIdle Idle = new StateIdle(this.gameObject);
            }
            if (rightLow || rightHigh || leftHigh || leftLow)
            {
                if (rightLow)
                {
                    if (leftLow)
                    {
                        Debug.Log("RLLL");
                        StateHands BothHands = new StateHands(this.gameObject, rightHand, leftHand, 1);
                    }
                    else
                    {
                        if (leftHigh)
                        {
                            Debug.Log("RLLH");
                            StateHands BothHands = new StateHands(this.gameObject, rightHand, leftHand, 4);
                        }
                        else
                        {
                            Debug.Log("RL");
                            StateHand RightHand = new StateHand(this.gameObject, rightHand, true);
                        }

                    }

                }
                else
                {
                    if (rightHigh)
                    {
                        if (leftLow)
                        {
                            Debug.Log("RHLL");
                            StateHands BothHands = new StateHands(this.gameObject, rightHand, leftHand, 3);
                        }
                        else
                        {
                            if (leftHigh)
                            {
                                Debug.Log("RHLH");
                                StateHands BothHands = new StateHands(this.gameObject, rightHand, leftHand, 2);
                            }
                            else
                            {
                                Debug.Log("RH");
                                StateHand RightHand = new StateHand(this.gameObject, rightHand, false);
                               
                            }
                        }
                    }
                    else
                    {
                       
                    }
                }
                if (leftLow && (!rightLow || !rightHigh))
                {
                    Debug.Log("LL");
                    StateHand LeftHand = new StateHand(this.gameObject, leftHand, true);
                }
                else
                {
                    if (leftHigh && (!rightLow || !rightHigh))
                    {
                        Debug.Log("LH");
                        StateHand LeftHand = new StateHand(this.gameObject, leftHand, false);
                    }
                    else
                    {
                        
                    }
                }
            }
            if (!rightLow && !rightHigh)
            {
                StateHand RightHand = new StateHand(rightHand);
            }
            if (!leftLow && !leftHigh)
            {
                StateHand LeftHand = new StateHand(leftHand);
            }
        }
        else
        {
            if (hasStep && stepUp)
            {
                StateStepUp StepUp = new StateStepUp(this.gameObject);
                StartCoroutine(DelayTranslate(0.25f));
                hasStep = false;
                idle = false;
            }
            else
            {
                if (hasFall && stepDown)
                {
                    transform.Translate(Vector3.forward * acceleration);
                    StartCoroutine(DelayIdle(1));

                }
                else
                {
                   
                }
            }
        }
    }

}
