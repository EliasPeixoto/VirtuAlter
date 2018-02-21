using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHands 
{
    // The variable state is used to determine wich combination of hands the script shoud activate.
    // 1 - leftLow and rightLow, 2 - leftHigh and rightHigh, 3 - leftLow and rightHigh, 4 - leftHigh and rightLow
    float highHeight = 0.8f;
    float lowHeight = 0f;
    float speed = 0.05f;
    public StateHands (GameObject obj,GameObject rightHand, GameObject leftHand, int state)
    {
        Debug.Log("Hands");
        //obj.transform.Translate(Vector3.forward * speed);
        rightHand.SetActive(true);
        leftHand.SetActive(true);
        switch (state)
        {
            case 1:
                rightHand.transform.localPosition = new Vector3(rightHand.transform.localPosition.x, lowHeight, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(leftHand.transform.localPosition.x, lowHeight, leftHand.transform.localPosition.z); 
                break;
            case 2:
                rightHand.transform.localPosition = new Vector3(rightHand.transform.localPosition.x, highHeight, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(leftHand.transform.localPosition.x, highHeight, leftHand.transform.localPosition.z);
                break;
            case 3:
                rightHand.transform.localPosition = new Vector3(rightHand.transform.localPosition.x, highHeight, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(leftHand.transform.localPosition.x, lowHeight, leftHand.transform.localPosition.z);
                break;
            case 4:
                rightHand.transform.localPosition = new Vector3(rightHand.transform.localPosition.x, lowHeight, rightHand.transform.localPosition.z);
                leftHand.transform.localPosition = new Vector3(leftHand.transform.localPosition.x, highHeight, leftHand.transform.localPosition.z);
                break;
            default:
                Debug.Log("Numero Inválido");
                break;
        }
    }
}
