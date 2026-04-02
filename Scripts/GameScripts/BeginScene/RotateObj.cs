using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotateSpeed;
    public bool judge;
    private float angle = 0;
    private float realRotateV;

    void Update()
    {
        realRotateV = rotateSpeed * Time.deltaTime;
        this.transform.Rotate(Vector3.up, realRotateV);
        angle += realRotateV;

        if((angle>30 || angle < -30) && judge)
        {
            rotateSpeed = -rotateSpeed;
        }
    }
}
