using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBase
{
    public WeaponObj nowWeapon;
    public Transform weaponPosition;
    public Camera deathCamera;

    private void Update()
    {
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
        {
            tankHead.transform.Rotate(0, - headSpeed * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            tankHead.transform.Rotate(0, headSpeed * Time.deltaTime, 0, Space.Self);
        }
        //tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }
    public override void Death()
    {
        Instantiate(deathCamera, this.transform.position, this.transform.rotation);
        base.Death();
        GameOutPanel.Instance.ShowPanel();
        GamePanel.Instance.HidePanel();
    }
    public override void Hurt(TankBase other)
    {
        base.Hurt(other);
        GamePanel.Instance.BloodUpdate(this.maxBlood, this.nowBlood);
    }
    public void ChangeWeapon(GameObject weapon)
    {
        nowWeapon = null;
        GameObject tempWeapon = Instantiate(weapon, weaponPosition, false);
        nowWeapon = tempWeapon.GetComponent<WeaponObj>();
        nowWeapon.SetHaver(this);
    }
    
}
