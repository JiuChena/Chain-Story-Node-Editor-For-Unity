using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraCtrl : MonoBehaviour
{
    public Transform player;
    private Transform mapCamera;
    void Start()
    {
        mapCamera = this.GetComponent<Transform>();
    }

    void Update()
    {
        mapCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
    }
}
