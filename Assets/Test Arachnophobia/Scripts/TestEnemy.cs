using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;

    private TestNexus target;

    private void Start()
    {
        target = FindObjectOfType<TestNexus>();
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
        Debug.Log("Enemy OnTriggerEnter with " + other.gameObject.name);

        if (other.gameObject.tag == target.tag)
        {
            target.InflictDamage(damage);
            Destroy(gameObject);
        }
    }

}
