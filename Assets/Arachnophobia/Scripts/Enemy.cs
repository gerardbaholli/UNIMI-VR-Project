using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;
    //[SerializeField] float damage;
    //[SerializeField] float life;

    private Nexus target; 

    private void Start()
    {
        target = FindObjectOfType<Nexus>();
    }

    private void FixedUpdate()
    {
        MoveTowardNexus();
    }

    private void MoveTowardNexus()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        // MAYBE TO BE REMOVED
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.transform.position) < 1f)
        {
            // Swap the position of the cylinder.
            target.transform.position *= -1.0f;
        }
    }
}
