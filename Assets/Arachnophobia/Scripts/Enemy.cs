using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Range(0f, 20f)] [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] int pointsForKilling;
    //[SerializeField] float life;

    private Nexus target;
    

    private void Start()
    {
        target = FindObjectOfType<Nexus>();
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
            target.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }

    public int GetPointsForKilling()
    {
        return pointsForKilling;
    }
}
