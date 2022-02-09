using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class TestEnemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float originalHealth;
    [SerializeField] int pointsForKilling;

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

        Debug.Log(healthbar.fillAmount);
    }

    private void MoveTowardNexus()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target.tag)
        {
            target.InflictDamage(damage);
            Destroy(gameObject);
        }
    }


    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
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
