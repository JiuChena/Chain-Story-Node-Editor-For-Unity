using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraCtrl : MonoBehaviour
{
    private Transform cameraTrans;
    private float y;

    private void Start()
    {
        cameraTrans = GetComponent<Transform>();
    }
    
    private void Update()
    {

        if (Input.GetKey(KeyCode.I))
        {
            cameraTrans.transform.Rotate(cameraTrans.transform.rotation.x <= 0 ? 0 : (-10 * Time.deltaTime), 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.O))
        {
            cameraTrans.transform.Rotate(cameraTrans.transform.rotation.x >= 90f ? 0 : (10 * Time.deltaTime), 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            y = cameraTrans.transform.position.y + 8 * Time.deltaTime;
            cameraTrans.transform.position = new Vector3(
                cameraTrans.transform.position.x, 
                y > 5  ? 5: y, 
                cameraTrans.transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            y = cameraTrans.transform.position.y - 8 * Time.deltaTime;
            cameraTrans.transform.position = new Vector3(
                cameraTrans.transform.position.x,
                y < 1.4f ? 1.4f : y,
                cameraTrans.transform.position.z);
        }
    }
}
