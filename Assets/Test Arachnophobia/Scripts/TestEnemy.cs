using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float originalHealth;
    [SerializeField] float currentHealth;

    private TestNexus target;
    private TestDrop drop;

    private void Start()
    {
        target = FindObjectOfType<TestNexus>();
        currentHealth = originalHealth;

        drop = GetComponent<TestDrop>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            MoveTowardNexus();
        }
        else
        {
            Destroy(gameObject);
        }
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
            RandomDrop();
            Destroy(gameObject);
        }
    }

    private void RandomDrop()
    {
        GameObject reward = drop.GenerateRandomDrop();
        if (reward != null)
        {
            Instantiate(reward, gameObject.transform.position, Quaternion.identity);
        }
    }


}
