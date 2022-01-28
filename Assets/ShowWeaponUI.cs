using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWeaponUI : MonoBehaviour
{

    private TestShootingSystem shootingSystem;
    private int selectedWeapon;

    private void Start()
    {
        shootingSystem = FindObjectOfType<TestShootingSystem>();
    }

    private void FixedUpdate()
    {
        UpdateSelectedWeapon();
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void UpdateSelectedWeapon()
    {
        selectedWeapon = shootingSystem.GetCurrentWeapon().GetWeaponID();
    }

}
