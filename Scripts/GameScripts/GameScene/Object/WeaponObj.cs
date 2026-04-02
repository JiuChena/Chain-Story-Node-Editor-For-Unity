using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] shootPos;
    public TankBase haver;
    public GameObject shootEff;

    private float time = 0.75f;
    private int bulletsRemain;

    private void Update()
    {
        time += Time.deltaTime;
    }
    public void SetHaver(TankBase haver)
    {
        this.haver = haver;
    }
    public void Fire()
    {
        bulletsRemain = Int32.Parse(GamePanel.Instance.remainLab.content.text);
        //子弹发射频率控制器
        if (((time - 0.75f) > 0) && bulletsRemain - shootPos.Length >= 0) 
        {
            time = 0;
            GamePanel.Instance.notice.content.text = "";
            for (int i = 0; i < shootPos.Length; i++)
            {
                GameObject tempEff = Instantiate(shootEff, shootPos[i].position, shootPos[i].rotation);
                GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
                BulletObj bulletObj = obj.GetComponent<BulletObj>();
                bulletObj.SetHaver(haver);
                Destroy(tempEff, 0.3f);
                GamePanel.Instance.RemainBullets(1);
            }
        }
        else if(bulletsRemain - shootPos.Length < 0)
        {
            GamePanel.Instance.notice.content.text = "Insuffcient bullets!";
        }
    }
}
