using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestory : MonoBehaviour
{
    public GameObject boxEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletObj>() != null)
        {
            Destroy(Instantiate(boxEff, this.transform.position, this.transform.rotation), 2);
            Destroy(this.gameObject); 
        }
    }
}
