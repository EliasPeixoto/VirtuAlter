using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHand
{
    float highHeight = 1.8f;
    float lowHeight = 1f;
    float speed = 0.05f;

    public StateHand(GameObject obj, GameObject hand, bool isLow)
    {
        Debug.Log("Hand");

        if (isLow)
        {
            hand.SetActive(true);
            hand.transform.localPosition = new Vector3(hand.transform.localPosition.x, lowHeight, hand.transform.localPosition.z);
        }
        else
        {
            hand.SetActive(true);
            hand.transform.localPosition = new Vector3(hand.transform.localPosition.x, highHeight, hand.transform.localPosition.z);
        }    
    }

    public StateHand(GameObject hand)
    {
        hand.SetActive(false);
    }
}
