using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float originalHealth;
    [SerializeField] int pointsForKilling;

    [Header("Destroy")]
    [SerializeField] GameObject impactOnNexusEffect;
    [SerializeField] GameObject destroyEffect;

    [Header("Graphic")]
    [SerializeField] Image healthbar;

    private GameStatus gameStatus;
    private Nexus target;
    private Drop dropManager;
    float currentHealth;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        target = FindObjectOfType<Nexus>();
        currentHealth = originalHealth;

        dropManager = GetComponent<Drop>();
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
            Instantiate(impactOnNexusEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public void InflictDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            gameStatus.AddPointsToScore(pointsForKilling);
            RandomDrop();
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void RandomDrop()
    {
        GameObject reward = dropManager.GenerateRandomDrop();
        if (reward != null)
        {
            GameObject drop = Instantiate(reward, gameObject.transform.position, Quaternion.identity);
            drop.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            Destroy(drop.gameObject, dropManager.GetSecondsAfterDestroyDrop());
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

}
