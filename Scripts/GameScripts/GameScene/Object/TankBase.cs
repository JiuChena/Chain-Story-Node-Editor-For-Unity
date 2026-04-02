using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    public float atk;
    public float def;
    public float maxBlood;
    public float nowBlood;
    public float moveSpeed = 10;
    public float roundSpeed = 50;
    public float headSpeed = 50;

    public Transform tankHead;
    public GameObject deathEff;

    /// <summary>
    /// 开火方法
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// 受伤方法
    /// </summary>
    /// <param name="tank"></param>
    public virtual void Hurt(TankBase other)
    {
        float dmg = other.atk - (this.def / other.atk) * this.def;
        if (dmg <= 0) return;
        this.nowBlood = this.nowBlood - dmg <= 0 ? 0 : this.nowBlood - dmg;
        if (nowBlood == 0) this.Death();
    }
    public virtual void Death()
    {
        Instantiate(deathEff, this.transform.position, this.transform.rotation);
        AudioSource audioSource = Instantiate(deathEff.GetComponent<AudioSource>(), this.transform.position, this.transform.rotation);
        audioSource.mute = !GameDataManger.Instance.musicData.onSound;
        audioSource.volume = GameDataManger.Instance.musicData.soundValue / 100;
        audioSource.Play();
        Destroy(this.gameObject);
    }

}
