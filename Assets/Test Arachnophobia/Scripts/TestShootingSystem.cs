using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TestShootingSystem : MonoBehaviour
{

    [SerializeField] TestWeapon[] weaponList;
    [SerializeField] TextMeshProUGUI cooldown;
    [SerializeField] float weaponRotationSpeed;
    [SerializeField] Transform weaponPos;
    [SerializeField] GameObject bullet;

    private TestWeapon standardWeapon;
    private TestWeapon currentWeapon;
    private GameObject currentWeaponMesh;
    private Vector3 collision = Vector3.zero;
    private float nextFire;


    private void Start()
    {
        standardWeapon = weaponList[1];
        currentWeapon = standardWeapon;
        currentWeaponMesh = Instantiate(currentWeapon.GetWeaponMesh(), weaponPos.position, new Quaternion(0, 0.7071f, 0, 0.7071f));        
    }

    private void FixedUpdate()
    {
        ShootRaycast();
        UpdateShootCooldown();
        RotateWeaponMesh();
    }

    private void RotateWeaponMesh()
    {
        currentWeaponMesh.transform.Rotate(Vector3.up * (weaponRotationSpeed * Time.deltaTime));
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

        if (Input.GetMouseButton(0) && Time.time > nextFire)
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
        Gizmos.DrawWireSphere(collision, 1f);
    }

}
