using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ShootingSystem : MonoBehaviour
{

    // DESIGN
    [Header("Basic")]
    [SerializeField] Camera arCamera;
    [SerializeField] Weapon[] weaponList;
    [SerializeField] TextMeshProUGUI cooldown;
    [SerializeField] TextMeshProUGUI ammo;
    [SerializeField] float weaponRotationSpeed;

    public enum SelectedWeapon { Pistol = 0, Uzi = 1, RocketLauncher = 2 }
    public SelectedWeapon selectedWeapon;

    // CACHE
    private Weapon standardWeapon;
    private Cooldown cooldownUI;
    private float nextFire;
    private Collider[] hitColliders;

    // CURRENT WEAPON INFO
    private Weapon currentWeapon;
    private GameStatus gameStatus;
    private AudioSource audioSource;
    public int ammoCounter;


    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        audioSource = GetComponent<AudioSource>();
        cooldownUI = FindObjectOfType<Cooldown>();
        standardWeapon = weaponList[0];
        currentWeapon = weaponList[0];
        ammoCounter = currentWeapon.GetAmmoCapacity();
        UpdateAmmoText();
    }

    public void ShootRaycast()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + currentWeapon.GetFireRate();
            audioSource.PlayOneShot(currentWeapon.GetShootSound());
            cooldownUI.StartCooldown();

            RaycastHit hit;

            if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            {
                Instantiate(currentWeapon.GetImpactEffect(), hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.transform.tag == "Enemy")
                {
                    CheckEnemyHit(hit);
                }
                else if (hit.transform.tag == "Weapon")
                {
                    CheckWeaponHit(hit);
                }
                else if (hit.transform.tag == "Power")
                {
                    CheckPowerHit(hit);
                }
            }
            UpdateAmmoCapability();
        }
    }

    private void CheckPowerHit(RaycastHit hit)
    {
        Effect drop = hit.collider.GetComponent<Effect>();
        drop.GetComponent<SlowerEffect>()?.TriggerEffect();
        drop.GetComponent<ExplosiveEffect>()?.TriggerEffect();
        drop.GetComponent<HealEffect>()?.TriggerEffect();
        drop.GetComponent<ShieldEffect>()?.TriggerEffect();
        Instantiate(drop.GetDestroyEffect(), drop.transform.position, Quaternion.identity);
        Destroy(drop.gameObject);
    }

    private void CheckWeaponHit(RaycastHit hit)
    {
        Weapon drop = hit.collider.GetComponent<Weapon>();
        if (drop != null)
        {
            currentWeapon = weaponList[drop.GetWeaponID()];
            ammoCounter = currentWeapon.GetAmmoCapacity();
            UpdateAmmoText();
            cooldownUI.SetCooldown(currentWeapon.GetFireRate());
            nextFire = Time.time;
            Destroy(drop.gameObject);
        }
    }

    private void CheckEnemyHit(RaycastHit hit)
    {
        Enemy enemy = hit.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.InflictDamage(currentWeapon.GetDamage());
        }

        if (currentWeapon.GetAOEDamage() > 0)
        {
            hitColliders = Physics.OverlapSphere(hit.point, currentWeapon.GetAOERadius());
            foreach (Collider hitCol in hitColliders)
            {
                enemy = hitCol.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.InflictDamage(currentWeapon.GetAOEDamage());
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

                if (ammoCounter <= 0)
                {
                    currentWeapon = standardWeapon;
                    cooldownUI.SetCooldown(currentWeapon.GetFireRate());
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

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public float GetWeaponRotationSpeed()
    {
        return weaponRotationSpeed;
    }

}
