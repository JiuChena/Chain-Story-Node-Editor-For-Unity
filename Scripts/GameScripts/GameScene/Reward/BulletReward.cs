using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReward : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerObj>() != null)
        {
            Destroy(this.gameObject);
            GamePanel.Instance.remainLab.content.text = (Int32.Parse(GamePanel.Instance.remainLab.content.text) + 40).ToString();
        }
    }
}
