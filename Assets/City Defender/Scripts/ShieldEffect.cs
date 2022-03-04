using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : Effect
{
    [SerializeField] float shieldDuration = 2.5f;
    [SerializeField] float sphereRadius = 2f;

    private Collider[] hitColliders;

    public void TriggerEffect()
    {
        CameraShield cameraShield = FindObjectOfType<CameraShield>();
        cameraShield.gameObject.SetActive(true);

        var endEffect = Time.time + shieldDuration;
        while(Time.time < endEffect)
        {
            hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
            foreach (Collider hitCol in hitColliders)
            {
                if (hitCol.tag == "Enemy")
                {
                    Enemy enemy = hitCol.GetComponent<Enemy>();
                    enemy.InflictDamage(enemy.GetOriginalHealth());
                }
            }
        }

        cameraShield.gameObject.SetActive(false);
    }

}
