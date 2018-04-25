using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{

    public GameObject PointA;
    public GameObject PointB;
    public bool GoingA = true;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        if (GoingA)
        {    
            GetComponent<NavMeshAgent>().SetDestination(PointA.transform.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(PointB.transform.position);
        }

    }
}
