using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterTank : TankBase
{
    //当前目标点
    private Transform targetPos;
    public Transform[] randomPos;
    public Transform lookAt;
    private UnityAction move;
    public TargetScripts Pos;
    public Transform[] shootPoints;
    public GameObject bullet;
    private float time;
    private float atkSpeed = 1.5f;
    private Vector3 screenPos;
    private Rect BKPos;
    private Rect HpPos;
    public Texture BK;
    public Texture Hp;
    private float showHpTime;

    private void Start()
    {
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    private void Update()
    {
        time += Time.deltaTime;
        lookAt = LookFirst() == null ? LookSecomd() : LookFirst();
        this.transform.LookAt(lookAt);
        move.Invoke();
    }

    private void OnGUI()
    {
        showHpTime -= Time.deltaTime;
        if (showHpTime > 0)
        {
            screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            BKPos = new Rect(screenPos.x, Screen.height - screenPos.y - 50, 100, 15);
            HpPos = new Rect(screenPos.x, Screen.height - screenPos.y - 50, 100 * (float)this.nowBlood / this.maxBlood, 15);

            GUI.DrawTexture(BKPos, BK);
            GUI.DrawTexture(HpPos, Hp);
        }
    }

    private Transform LookSecomd()
    {
        if (LookFirst() == null)
        {
            move = () =>
            {
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            };
        }
        

        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.1f)
        {
            return targetPos = randomPos[Random.Range(0, randomPos.Length)];
        }
        return targetPos;
    }
    private Transform LookFirst()
    {
        if (Pos.target == null)
        {
            return null;
        }
        else if (Vector3.Distance(this.transform.position, Pos.target.position) < 6) 
        {
            move = () =>
            {
                Fire();
            };
            return Pos.target;
        }
        else
        {
            move = () =>
            {
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                Fire();
            };
            return Pos.target;
        }
    }

    public override void Fire()
    {
        for (int i = 0; (i < shootPoints.Length) && time > atkSpeed; i++)
        {
            time = 0;
            GameObject obj = Instantiate(bullet, shootPoints[i].position, shootPoints[i].rotation);
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetHaver(this);
        }
    }

    public override void Hurt(TankBase other)
    {
        base.Hurt(other);
        showHpTime = 3;
    }
}
