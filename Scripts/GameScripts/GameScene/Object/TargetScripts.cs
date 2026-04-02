using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScripts : MonoBehaviour
{
    public Transform target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerObj>() != null)
        {
            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerObj>() != null)
        {
            target = null;
        }
    }

}
