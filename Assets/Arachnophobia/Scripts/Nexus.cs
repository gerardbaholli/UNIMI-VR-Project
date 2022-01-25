using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{

    [SerializeField] float originalLife;

    private float currentLife;

    private void Start()
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

    public void ApplyDamage(float damage)
    {
        currentLife -= damage;
    }

}
