using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] Weapons;
    //public GameObject changeWeaponEff;
    private int index;

    private void Start()
    {
        //this.changeWeaponEff.GetComponent<AudioSource>().volume = GameDataManger.Instance.musicData.musicValue / 100;
        //this.changeWeaponEff.GetComponent<AudioSource>().mute = !GameDataManger.Instance.musicData.onSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(Instantiate(changeWeaponEff, this.transform.position - new Vector3(0, 1, 0), this.transform.rotation), 2);
            Destroy(this.gameObject);
            index = Random.Range(0, Weapons.Length);
            other.GetComponent<PlayerObj>().ChangeWeapon(Weapons[index]);
        }
    }
    
}
