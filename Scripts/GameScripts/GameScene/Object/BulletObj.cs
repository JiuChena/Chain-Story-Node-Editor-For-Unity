using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float bulletSpeed = 50;
    //谁发射的子弹
    public TankBase haver;
    public GameObject bulletEff;

    private void Start()
    {
        this.bulletEff.GetComponent<AudioSource>().volume = GameDataManger.Instance.musicData.soundValue / 100;
        this.bulletEff.GetComponent<AudioSource>().mute = !GameDataManger.Instance.musicData.onSound;
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject != null &&
           (other.tag == "Destory" ||
           (other.tag == "Player" && haver.tag == "Monster") ||
           (other.tag == "Monster" && haver.tag == "Player")))
            {
                TankBase obj = other.GetComponent<TankBase>();
                if (obj != null)
                {
                    obj.Hurt(haver);
                }
                if (bulletEff != null)
                {
                    GameObject tempEff = Instantiate(bulletEff, this.transform.position, this.transform.rotation);
                    tempEff.GetComponent<AudioSource>().volume = GameDataManger.Instance.musicData.soundValue / 100;
                    if (GameDataManger.Instance.musicData.onSound) tempEff.GetComponent<AudioSource>().Play();
                    else tempEff.GetComponent<AudioSource>().Stop();
                    Destroy(tempEff, 2);
                }
                Destroy(this.gameObject);
            }
        }
        catch
        {

        }
    }

    public void SetHaver(TankBase haver)
    {
        this.haver = haver;
    }
}
