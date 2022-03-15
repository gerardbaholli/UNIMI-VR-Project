using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShield : MonoBehaviour
{

    [SerializeField] SpriteRenderer shieldSprite;

    private bool isEffectActive = false;

    private void Start()
    {
        shieldSprite.enabled = false;
    }

    public void ActivateShield(float shieldDuration)
    {
        Debug.Log("ActivateShield");
        StartCoroutine(StartShieldFury(shieldDuration));
    }

    private IEnumerator StartShieldFury(float shieldDuration)
    {
        Debug.Log("START Shield Fury");
        isEffectActive = true;
        shieldSprite.enabled = true;
        yield return new WaitForSeconds(shieldDuration);
        shieldSprite.enabled = false;
        isEffectActive = false;
        Debug.Log("END Shield Fury");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isEffectActive)
            return;

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("FIND ENEMY " + other.gameObject.name);
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.InflictDamage(enemy.GetOriginalHealth());
        }     
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isEffectActive)
            return;

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("FIND ENEMY " + other.gameObject.name);
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.InflictDamage(enemy.GetOriginalHealth());
        }
    }


}
