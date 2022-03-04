using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderShield : MonoBehaviour
{
    [SerializeField] float shieldDuration = 1f;

    private CameraShield cameraShield;
    private bool isEffectActive = false;

    private void Start()
    {
        cameraShield = FindObjectOfType<CameraShield>();
        cameraShield.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(StartShieldFury());
        }
    }

    private IEnumerator StartShieldFury()
    {
        isEffectActive = true;
        cameraShield.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(shieldDuration);
        cameraShield.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isEffectActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEffectActive)
            if (other.gameObject.tag == "Enemy")
                Destroy(other.gameObject);
    }

}
