using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNexus : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float originalLife;
    public float currentLife;

    [Header("Destroy")]
    [SerializeField] GameObject destroyEffect;
    [SerializeField] GameObject fireEffect;
    [SerializeField] AudioClip destroySound1;
    [SerializeField] AudioClip destroySound2;

    [SerializeField] Image healthbar;

    void Start()
    {
        currentLife = originalLife;
    }

    void FixedUpdate()
    {
        CheckLife();
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        healthbar.fillAmount = currentLife / originalLife;
    }

    private void CheckLife()
    {
        if (currentLife <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(destroySound1, transform.position);
            AudioSource.PlayClipAtPoint(destroySound2, transform.position);
            Destroy(gameObject);
        }
    }

    public void InflictDamage(float damage)
    {
        currentLife -= damage;
    }

}
