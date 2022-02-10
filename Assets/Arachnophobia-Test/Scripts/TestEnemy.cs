using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class TestEnemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float originalHealth;
    [SerializeField] int pointsForKilling;

    [Header("Destroy")]
    [SerializeField] GameObject destroyEffect;
    [SerializeField] AudioClip destroySound;

    [Header("Graphic")]
    [SerializeField] Image healthbar;

    private TestNexus target;
    private float currentHealth;

    private void Start()
    {
        target = FindObjectOfType<TestNexus>();
        currentHealth = originalHealth;
    }

    private void FixedUpdate()
    {
        if (target == null)
            Destroy(gameObject);

        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        healthbar.fillAmount = currentHealth / originalHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target.tag)
        {
            target.InflictDamage(damage);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            Destroy(gameObject);
        }
    }


    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            Destroy(gameObject);
        }
    }

    public int GetPointsForKilling()
    {
        return pointsForKilling;
    }

    public float GetSpeed()
    {
        return speed;
    }


}
