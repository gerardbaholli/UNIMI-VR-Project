using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAmmoUI : MonoBehaviour
{

    private ShootingSystem shootingSystem;
    private int selectedWeapon;

    private void Start()
    {
        shootingSystem = FindObjectOfType<ShootingSystem>();
    }

    private void FixedUpdate()
    {
        UpdateSelectedWeapon();
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform ammo in transform)
        {
            if (i == selectedWeapon)
            {
                ammo.gameObject.SetActive(true);
            }
            else
            {
                ammo.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void UpdateSelectedWeapon()
    {
        selectedWeapon = shootingSystem.GetCurrentWeapon().GetWeaponID();
    }

}
