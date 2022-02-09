using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
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
        transform.position += transform.up * Mathf.Sin(Time.time * 3f) * 0.01f;
        //transform.position += transform.right * Mathf.Sin(Time.time * 3f) * 0.05f;
    }

}
