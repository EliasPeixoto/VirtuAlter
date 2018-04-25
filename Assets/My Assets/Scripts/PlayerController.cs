using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject RightHand;
    public GameObject LeftHand;

    public float lowHeight = 1.1f;
    public float highHeight = 1.8f;

    public float speed = 1;
    public float stepForce = 1;

    IEnumerator DelayStep()
    {
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.Translate(Vector3.up * 0.8f);
        yield return new WaitForSeconds(0.025f);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 3f, ForceMode.Impulse);
    }

    public void Step()
    {
        StartCoroutine(DelayStep());
    }

    public void DeactivateHands(string layerName)
    {
        if (layerName == "Right Hand")
        {
            RightHand.SetActive(false);
        }
        else
        {
            LeftHand.SetActive(false);
        }
    }

    public void HandBehaviour(string layerName, AnimatorStateInfo state)
    {
        if (layerName == "Right Hand")
        {
            if (state.IsName("Hand High"))
            {
                RightHand.SetActive(true);
                RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, highHeight, 0.2f);
            }
            else
            {
                RightHand.SetActive(true);
                RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, lowHeight, 0.25f);
            }
        }
        else
        {
            if (state.IsName("Hand High"))
            {
                LeftHand.SetActive(true);
                LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, highHeight, 0.2f);
            }
            else
            {
                LeftHand.SetActive(true);
                LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, lowHeight, 0.25f);
            }
        }

    }



    void FixedUpdate()
    {
        if (Input.GetButton("Walk"))
        {
            GetComponent<Animator>().SetBool("Is Walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Is Walking", false);
        }
        if (Input.GetButton("LeftLow"))
        {
            GetComponent<Animator>().SetBool("Left Low", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Left Low", false);
        }

        if (Input.GetButton("LeftHigh"))
        {
            GetComponent<Animator>().SetBool("Left High", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Left High", false);
        }

        if (Input.GetButton("RightLow"))
        {
            GetComponent<Animator>().SetBool("Right Low", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Right Low", false);
        }

        if (Input.GetButton("RightHigh"))
        {
            GetComponent<Animator>().SetBool("Right High", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Right High", false);
        }

        if (Input.GetButton("StepUp"))
        {
            GetComponent<Animator>().SetBool("StepUp", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("StepUp", false);
        }

        if (Input.GetButtonUp("StepUp"))
        {
            GetComponent<Animator>().SetBool("StepDown", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("StepDown", false);
        }
    }
}
