using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] int weaponID;
    [SerializeField] string weaponName;

    [Header("Stats")]
    [SerializeField] float weaponDamage;
    [SerializeField] float fireRate;
    [SerializeField] float weaponRange;
    [SerializeField] int ammoCapacity;
    [SerializeField] float AOEDamage;
    [SerializeField] float AOERadius;


    [Header("Graphics")]
    [SerializeField] GameObject weaponMesh;
    [SerializeField] GameObject bulletMesh;
    [SerializeField] AudioClip shootSound;
    [SerializeField] GameObject impactEffect;

    private ShootingSystem shootingSystem;
    private float weaponRotationSpeed;

    private void Start()
    {
        shootingSystem = FindObjectOfType<ShootingSystem>();
    }

    private void FixedUpdate()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        weaponRotationSpeed = shootingSystem.GetWeaponRotationSpeed();
        gameObject.transform.Rotate(Vector3.up * (weaponRotationSpeed * Time.deltaTime));
    }

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

    public float GetAOEDamage()
    {
        return AOEDamage;
    }

    public float GetAOERadius()
    {
        return AOERadius;
    }
}
