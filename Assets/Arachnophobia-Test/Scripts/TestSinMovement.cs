using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSinMovement : MonoBehaviour
{
    private TestNexus target;
    private float speed;

    private void Start()
    {
        target = FindObjectOfType<TestNexus>();
        speed = GetComponent<TestEnemy>().GetSpeed();
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        transform.position += transform.up * Mathf.Sin(Time.time * 2f) * 0.01f;
    }

}
