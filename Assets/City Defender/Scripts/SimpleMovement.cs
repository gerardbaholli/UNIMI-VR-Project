using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private Nexus target;
    private float speed;

    private void Start()
    {
        target = FindObjectOfType<Nexus>();
        speed = GetComponent<Enemy>().GetSpeed();
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

}
