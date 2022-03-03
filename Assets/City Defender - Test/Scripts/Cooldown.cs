using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{

    [SerializeField] Image cooldownImage;

    private float cooldownValue;
    private float nextFire = 0f;

    private void Start()
    {
        cooldownValue = FindObjectOfType<ShootingSystem>().GetCurrentWeapon().GetFireRate();
        cooldownImage.color = new Color(0f, 1f, 0.2f);
    }

    private void FixedUpdate()
    {
        UpdateCircle();
    }

    private void UpdateCircle()
    {
        cooldownImage.fillAmount = 1 - (nextFire - Time.time) / cooldownValue;
        
        if (cooldownImage.fillAmount >= 1)
        {
            cooldownImage.color = new Color(0f, 1f, 0.2f);
        }
        else
        {
            float red = 1;
            float green = 1 - (nextFire - Time.time) / cooldownValue;
            float blue = 0.2f;
            cooldownImage.color = new Color(red, green, blue);
        }
    }

    public void StartCooldown()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + cooldownValue;
        }
    }

    public void SetCooldown(float value)
    {
        cooldownValue = value;
    }

}
