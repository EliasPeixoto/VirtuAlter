using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDetection : MonoBehaviour
{

    public GameObject floorDetect;
    public GameObject stepDetect;
    public GameObject fallDetect;

    int layerMask = 1 << 8;

    void Update()
    {
        Vector3 centerposition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Vector3 feetposition = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);

        FloorDetection(centerposition);
        FallDetection(centerposition);
        StepDetect(feetposition);
    }

    IEnumerator ObjectCoolDown(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(5f);
        obj.SetActive(true);
    }

    void FallDetection(Vector3 position)
    {
        if (!Physics.Linecast(position, fallDetect.transform.position, layerMask))
        {
            GetComponent<Animator>().SetBool("HasFall", true);
            if (fallDetect.activeSelf)
            {
                //GetComponent<StateMachine>().idle = true;
                StartCoroutine(ObjectCoolDown(fallDetect));
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("HasFall", false);
        }
    }

    void FloorDetection(Vector3 position)
    {
        if (Physics.Linecast(position, floorDetect.transform.position, layerMask))
        {
            GetComponent<Animator>().SetBool("HasFloor", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("HasFloor", false);
        }
    }

    void StepDetect(Vector3 position)
    {
       
        if (Physics.Linecast(position, stepDetect.transform.position, layerMask))
        {
            GetComponent<Animator>().SetBool("HasStep", true);
            if (stepDetect.activeSelf)
            {
                //GetComponent<StateMachine>().idle = true;
                StartCoroutine(ObjectCoolDown(stepDetect));
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("HasStep", false);
        }
    }
}
