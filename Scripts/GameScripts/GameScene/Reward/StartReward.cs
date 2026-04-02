using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartReward : MonoBehaviour
{
    public CustomGUILabel score;
    public GameObject startEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerObj>() != null)
        {
            Destroy(Instantiate(startEff, this.transform.position, this.transform.rotation), 2);
            Destroy(this.gameObject);
            GamePanel.Instance.ScoreUpdate( 3 );
        }
    }
}
