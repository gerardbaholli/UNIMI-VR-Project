using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    [SerializeField] string weaponName;
    [SerializeField] float weaponDamage;
    [SerializeField] float fireRate;
    [SerializeField] float weaponRange;
    [SerializeField] GameObject weaponMesh;
    [SerializeField] GameObject bulletMesh;
    [SerializeField] AudioClip shootSound;

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

}
