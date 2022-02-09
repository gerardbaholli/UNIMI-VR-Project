using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{

    [SerializeField] float originalLife;
    //[SerializeField] GameObject destroyEffect;

    public float currentLife;


    private void Start()
    {
        currentLife = originalLife;
    }

    void FixedUpdate()
    {
        CheckLife();
    }

    public int GetCurrentLife()
    {
        return (int) currentLife;
    }

    private void CheckLife()
    {
        if (currentLife <= 0)
            //Instantiate(destroyEffect, transform.position, Quaternion.identity); non funziona
            Destroy(gameObject);
    }

    public void InflictDamage(float damage)
    {
        currentLife -= damage;
    }

}
