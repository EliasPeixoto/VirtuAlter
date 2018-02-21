using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            PlayerScore.AddScore();
            Destroy(this.gameObject);
        }
      
    }
}
