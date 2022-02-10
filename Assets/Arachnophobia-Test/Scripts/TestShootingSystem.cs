using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TestShootingSystem : MonoBehaviour
{
    // DESIGN
    [Header("Basic")]
    [SerializeField] TestWeapon[] weaponList;
    [SerializeField] TextMeshProUGUI cooldown;
    [SerializeField] TextMeshProUGUI ammo;
    [SerializeField] float weaponRotationSpeed;

    [Header("Test")]
    [SerializeField] Transform weaponPos;

    public enum SelectedWeapon { Pistol = 0, Uzi = 1 , RocketLauncher = 2}
    public SelectedWeapon selectedWeapon;

    // CACHE
    private TestWeapon standardWeapon;
    private float nextFire;
    private Collider[] hitColliders;

    // CURRENT WEAPON INFO
    private TestWeapon currentWeapon;
    private AudioSource audioSource;
    public int ammoCounter;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        standardWeapon = weaponList[0];
        currentWeapon = weaponList[1];
        ammoCounter = currentWeapon.GetAmmoCapacity();
        UpdateAmmoText();
    }

    private void FixedUpdate()
    {
        ShootRaycast();
        UpdateShootCooldown();
    }



    private void UpdateShootCooldown()
    {
        if (nextFire - Time.time < 0)
        {
            cooldown.text = "READY";
        }
        else
        {
            cooldown.text = (nextFire - Time.time).ToString("F2");
        }
    }

    private void ShootRaycast()
    {
        if (Input.GetMouseButton(1) && Time.time > nextFire)
        {
            nextFire = Time.time + currentWeapon.GetFireRate();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, currentWeapon.GetWeaponRange()))
            {
                audioSource.PlayOneShot(currentWeapon.GetShootSound());
                Instantiate(currentWeapon.GetImpactEffect(), hit.point, Quaternion.LookRotation(hit.normal));
                CheckDropHit(hit);
                CheckEnemyHit(hit);
            }

            UpdateAmmoCapability();
        }
    }

    private void CheckDropHit(RaycastHit hit)
    {
        TestWeapon drop = hit.collider.GetComponent<TestWeapon>();
        if (drop != null)
        {
            currentWeapon = weaponList[drop.GetWeaponID()];
            ammoCounter = currentWeapon.GetAmmoCapacity();
            UpdateAmmoText();
            Destroy(drop.gameObject);
        }
    }

    private void CheckEnemyHit(RaycastHit hit)
    {
        TestEnemy enemy = hit.collider.GetComponent<TestEnemy>();
        if (enemy != null)
        {
            enemy.Damage(currentWeapon.GetDamage());
        }

        if (currentWeapon.GetAOEDamage() > 0)
        {
            hitColliders = Physics.OverlapSphere(hit.point, currentWeapon.GetAOERadius());
            foreach (Collider hitCol in hitColliders)
            {
                enemy = hitCol.GetComponent<TestEnemy>();
                if (enemy != null)
                {
                    enemy.Damage(currentWeapon.GetAOEDamage());
                }
            }
        }
    }

    private void UpdateAmmoCapability()
    {
        if (currentWeapon != standardWeapon)
        {
            if (ammoCounter > 0)
            {
                ammoCounter--;

                if (ammoCounter == 0)
                {
                    currentWeapon = standardWeapon;
                    ammoCounter = currentWeapon.GetAmmoCapacity();
                }
            }

            UpdateAmmoText();
        }
    }

    private void UpdateAmmoText()
    {
        if (ammoCounter != -1)
        {
            ammo.text = ammoCounter.ToString();
        }
        else
        {
            ammo.text = "inf";
        }
    }

    public TestWeapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public float GetWeaponRotationSpeed()
    {
        return weaponRotationSpeed;
    }

}
