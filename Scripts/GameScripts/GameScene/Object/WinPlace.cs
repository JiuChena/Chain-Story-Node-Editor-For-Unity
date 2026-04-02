using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerObj>() != null)
        {
            GamePanel.Instance.HidePanel();
            WinPanel.Instance.ShowPanel();
            Time.timeScale = 0;
        }
    }
}
