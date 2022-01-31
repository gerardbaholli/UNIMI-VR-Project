using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] int weaponID;
    [SerializeField] string weaponName;

    [Header("Stats")]
    [SerializeField] float weaponDamage;
    [SerializeField] float fireRate;
    [SerializeField] float weaponRange;
    [SerializeField] int ammoCapacity;

    [Header("Graphics")]
    [SerializeField] GameObject weaponMesh;
    [SerializeField] GameObject bulletMesh;
    [SerializeField] AudioClip shootSound;
    [SerializeField] GameObject impactEffect;


    public int GetWeaponID()
    {
        return weaponID;
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }

    public float GetDamage()
    {
        return weaponDamage;
    }

    public GameObject GetWeaponMesh()
    {
        return weaponMesh;
    }

    public AudioClip GetShootSound()
    {
        return shootSound;
    }

    public GameObject GetImpactEffect()
    {
        return impactEffect;
    }

    public int GetAmmoCapacity()
    {
        return ammoCapacity;
    }

}
