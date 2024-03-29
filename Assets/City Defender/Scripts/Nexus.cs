using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] float originalLife;
    private float currentLife;

    [Header("Destroy")]
    [SerializeField] GameObject destroyEffect;
    [SerializeField] GameObject fireEffect;
    [SerializeField] AudioClip destroySound1;
    [SerializeField] AudioClip destroySound2;

    private Image healthbarImage;

    private void Start()
    {
        currentLife = originalLife;
        healthbarImage = FindObjectOfType<Healthbar>().GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (healthbarImage == null)
        {
            healthbarImage = FindObjectOfType<Healthbar>().GetComponent<Image>();
        }


        CheckLife();
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        healthbarImage.fillAmount = currentLife / originalLife;
    }

    private void CheckLife()
    {
        if (currentLife <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(destroySound1, transform.position);
            AudioSource.PlayClipAtPoint(destroySound2, transform.position);
            Destroy(gameObject);
        }
    }

    public void InflictDamage(float damage)
    {
        currentLife -= damage;
    }

    public float GetCurrentLife()
    {
        return currentLife;
    }

    public float GetOriginalLife()
    {
        return originalLife;
    }

    public void SetLife(float value)
    {
        currentLife = value;
    }

}
