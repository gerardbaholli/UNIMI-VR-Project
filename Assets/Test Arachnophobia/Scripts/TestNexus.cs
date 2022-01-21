using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNexus : MonoBehaviour
{
    [SerializeField] float originalLife;

    public float currentLife;


    void Start()
    {
        currentLife = originalLife;

    }

    void FixedUpdate()
    {
        CheckLife();
    }

    private void CheckLife()
    {
        if (currentLife <= 0)
            Destroy(gameObject);
    }

    public void InflictDamage(float damage)
    {
        currentLife -= damage;
    }

}
