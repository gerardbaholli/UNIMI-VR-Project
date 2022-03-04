using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderShield : MonoBehaviour
{
    [SerializeField] float sphereRadius = 2f;
    private Collider[] hitColliders;

    private void FixedUpdate()
    {
        hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        foreach (Collider hitCol in hitColliders)
        {
            if (hitCol.tag == "Enemy")
                Destroy(hitCol.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }

}
