using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativePlayerController : MonoBehaviour
{
    public float forwardForce = 1;
    public float jumpforce = 1;
    public GameObject RightHand;
    public GameObject LeftHand;
    bool rightLow = false;
    bool rightHigh = false;
    bool leftLow = false;
    bool leftHigh = false;
    bool idle = false;
    public bool hasFloor;
    public bool hasFall;

    bool isGetDownOnCooldown = false;

    void FixedUpdate()
    {
        Step();
        GetDown();
        RightHandLow();
        LeftHandLow();
        RightHandHigh();
        LeftHandHigh();
        //RightHighAndLeftLow();
        //RightLowAndLeftHigh();
        DeactivateHands();
    }

    IEnumerator GetDownCooldown()
    {
        isGetDownOnCooldown = true;
        yield return new WaitForSeconds(1f);
        isGetDownOnCooldown = false;
    }

    IEnumerator StepDelay()
    {
        yield return new WaitForSeconds(0.6f);
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpforce);//It makes the character jump.
        //StepMovement.isEnabled = true;
    }

    IEnumerator GetDownDelay()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector3.forward * 0.25f);
        yield return new WaitForSeconds(0.5f);
        //StepMovement.isEnabled = true;
    }

    void StateMachine()
    {
        if (Input.GetButton("Jump") && idle && hasFloor && !GetComponent<Animator>().GetBool("HasFall"))
        {
            Step();
        }
        if (Input.GetButton("GetDown") && GetComponent<Animator>().GetBool("Idle") && GetComponent<Animator>().GetBool("HasFloor") && GetComponent<Animator>().GetBool("HasFall") && !isGetDownOnCooldown)
        {

        }
    }


    void Step()
    {
        //if the character is not jumping or falling and canStep is true.
        StartCoroutine(StepDelay());//Delays the character movement for better Animation/Movement Sychronization.
        GetComponent<Animator>().SetTrigger("Step");
        GetComponent<Animator>().SetBool("Idle", false);
    }

    void GetDown()
    {
        if (Input.GetButton("GetDown") && GetComponent<Animator>().GetBool("Idle") && GetComponent<Animator>().GetBool("HasFloor") && GetComponent<Animator>().GetBool("HasFall") && !isGetDownOnCooldown)
        {
            StartCoroutine(GetDownDelay());
            StartCoroutine(GetDownCooldown());
            GetComponent<Animator>().SetTrigger("GetDown");
            GetComponent<Animator>().SetBool("Idle", false);
        }
			
    }

    void RightHandLow()
    {
        if (Input.GetButton("RightHandLow") && !Input.GetButton("LeftHandLow") && !Input.GetButton("LeftHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkRightHandLow");
            RightHand.SetActive(true);
            RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, 0.8f, RightHand.transform.localPosition.z);
        }
        else
        {
            if (!Input.GetButton("RightHandHigh"))
            {
                GetComponent<Animator>().SetBool("RightHandLow", false);
                //RightHand.SetActive(false);
            }
        }
    }

    void LeftHandLow()
    {
        if (Input.GetButton("LeftHandLow") && !Input.GetButton("RightHandHigh") && !Input.GetButton("RightHandLow") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkLeftHandLow");
            LeftHand.SetActive(true);
            LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, 0.8f, LeftHand.transform.localPosition.z);
        }
        else
        {
            if (!Input.GetButton("LeftHandHigh"))
            {
				
                // LeftHand.SetActive(false);
            }
        }
    }

    void RightHandHigh()
    {
        if (Input.GetButton("RightHandHigh") && !Input.GetButton("LeftHandLow") && !Input.GetButton("LeftHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkRightHandHigh");	
            RightHand.SetActive(true);
            RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, 1.35f, RightHand.transform.localPosition.z);
        }
        /*else
		{
			if (!Input.GetButton("RightHandLow"))
			{
				
				//  RightHand.SetActive(false);
			}
		}*/
    }

    void LeftHandHigh()
    {
        if (Input.GetButton("LeftHandHigh") && !Input.GetButton("RightHandLow") && !Input.GetButton("RightHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkLeftHandHigh");	
            LeftHand.SetActive(true);
            LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, 1.35f, LeftHand.transform.localPosition.z);
        }
        /*else
		{
			if (!Input.GetButton("LeftHandLow"))
			{
				
				// LeftHand.SetActive(false);
			}
		}*/
    }

    void RightHighAndLeftLow()
    {
        if (Input.GetButton("RightHandHigh") && Input.GetButton("LeftHandLow") && !GetComponent<Animator>().GetBool("Idle"))
        {
			
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
            RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, 1.35f, RightHand.transform.localPosition.z);
            LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, 0.8f, LeftHand.transform.localPosition.z);
        }
        else
        {
            if (!Input.GetButton("RightHandHigh") || !Input.GetButton("LeftHandLow"))
            {
				
                //RightHand.SetActive (false);
                //LeftHand.SetActive (false);
            }
        }
    }

    void RightLowAndLeftHigh()
    {
        if (Input.GetButton("RightHandLow") && Input.GetButton("LeftHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
			
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
            RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, 0.8f, RightHand.transform.localPosition.z);
            LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, 1.35f, LeftHand.transform.localPosition.z);
        }
        else
        {
            if (!Input.GetButton("RightHandLow") || !Input.GetButton("LeftHandHigh"))
            {
				
                //RightHand.SetActive (false);
                //LeftHand.SetActive (false);
            }
        }
    }

    void RightLowAndLeftLow()
    {
        if (Input.GetButton("RightHandLow") && Input.GetButton("LeftHandLow"))
        {
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
        }
    }

    void DeactivateHands()
    {
        if (!Input.GetButton("RightHandHigh") && !Input.GetButton("RightHandLow") && !Input.GetButton("RightHighAndLeftLow") && !Input.GetButton("RightLowAndLeftHigh"))
            RightHand.SetActive(false);
		
        if (!Input.GetButton("LeftHandHigh") && !Input.GetButton("LeftHandLow") && !Input.GetButton("RightHighAndLeftLow") && !Input.GetButton("RightLowAndLeftHigh"))
            LeftHand.SetActive(false);
    }
}

