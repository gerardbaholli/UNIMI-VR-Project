using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TestShootingSystem : MonoBehaviour
{

    [SerializeField] TestWeapon[] weaponList;
    [SerializeField] TextMeshProUGUI cooldown;
    [SerializeField] GameObject bullet;

    private TestWeapon currentWeapon;
    private Vector3 collision = Vector3.zero;
    private float nextFire;

    private void Start()
    {
        currentWeapon = weaponList[0];
        Instantiate(currentWeapon.GetWeaponMesh(), new Vector3(0, 3, 0), new Quaternion(0, 0.7071f, 0, 0.7071f));        
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
        if (Time.time > nextFire)
        {
            Debug.Log("READY TO HIT");
        }
        else
        {
            Debug.Log("NOT READY TO HIT");
        }

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + currentWeapon.GetFireRate();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, currentWeapon.GetWeaponRange()))
            {
                Instantiate(bullet, hit.point, Quaternion.identity);
                TestEnemy enemy = hit.collider.GetComponent<TestEnemy>();

                if (enemy != null)
                {
                    Debug.Log("Hit: " + enemy.name);
                    collision = hit.point;
                    enemy.Damage(currentWeapon.GetDamage());
                }
                else
                {
                    Debug.Log("NOT HIT");
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }

}
