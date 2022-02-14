using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private Enemy enemy;
    private Nexus target;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        target = FindObjectOfType<Nexus>();
    }

    private void FixedUpdate()
    {
        float step = enemy.GetSpeed() * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

}
