using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBase
{
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    private int count = 0;
    private bool judge = false;

    public Transform[] shootPoints;
    public GameObject bullet;
    void Start()
    {
        bullet.GetComponent<BulletObj>().bulletSpeed = 30;
    }

    void Update()
    {
    Flag:
        nowTime += Time.deltaTime;
        if (nowTime >= fireOffsetTime)
        {
            Fire();
            if (count == 8 || judge)
            {
                count--;
                nowTime = fireOffsetTime - 0.3f;
                if (count == 0) judge = false;
                if (count == 7) judge = true;
                goto Flag;
            }
            nowTime = 0;
            count++;
        }
    }

    public override void Fire()
    {
        for(int i = 0; i < shootPoints.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPoints[i].position, shootPoints[i].rotation);
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetHaver(this);
        }
    }

    public override void Hurt(TankBase other)
    {
        //重写受伤方法，使得固定的坦克不受伤害
    }
}
