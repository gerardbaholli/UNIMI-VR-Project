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
        cooldownImage.color = new Color(0f, 1f, 0.35f);
    }

    private void FixedUpdate()
    {
        UpdateCircle();
        Debug.Log(cooldownValue);
    }

    private void UpdateCircle()
    {
        cooldownImage.fillAmount = 1 - (nextFire - Time.time) / cooldownValue;

        float red = (nextFire - Time.time) / cooldownValue;
        float green = 1 - (nextFire - Time.time) / cooldownValue;
        float blue = 0.35f;
        cooldownImage.color = new Color(red, green, blue);
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
