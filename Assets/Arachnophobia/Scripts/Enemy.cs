using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float originalHealth;
    public float currentHealth;
    [SerializeField] int pointsForKilling;

    private GameStatus gameStatus;
    private Nexus target;
    private Drop dropManager;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        target = FindObjectOfType<Nexus>();
        currentHealth = originalHealth;

        dropManager = GetComponent<Drop>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            //MoveTowardNexus();
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
            gameStatus.AddPointsToScore(pointsForKilling);
            RandomDrop();
            Destroy(gameObject);
        }
    }

    private void RandomDrop()
    {
        GameObject reward = dropManager.GenerateRandomDrop();
        if (reward != null)
        {
            GameObject drop = Instantiate(reward, gameObject.transform.position, Quaternion.identity);
            Destroy(drop.gameObject, dropManager.GetSecondsAfterDestroyDrop());
        }
    }

}
