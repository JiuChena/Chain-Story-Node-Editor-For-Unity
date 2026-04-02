using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    public CustomGUILabel bloodLab;
    public CustomGUITexture bloodTex;
    public GameObject recoverEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerObj>() != null)
        {
            Destroy(Instantiate(recoverEff, other.transform.position, other.transform.rotation), 2);
            Destroy(this.gameObject);
            bloodLab.content.text = ((Int32.Parse(bloodLab.content.text) + 20) >= 100 ? 100 : (Int32.Parse(bloodLab.content.text) + 20)).ToString();
            bloodTex.GUIPos.Width = float.Parse(bloodLab.content.text) * 2;
        }
    }
}
