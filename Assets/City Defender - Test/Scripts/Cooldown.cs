using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{

    [SerializeField] Image cooldownImage;
    [SerializeField] float cooldownValue;

    private float nextFire = 0f;

    private void FixedUpdate()
    {
        Shoot();
        UpdateCircle();
    }


    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + cooldownValue;
            }
        }

    }


    private void UpdateCircle()
    {
        cooldownImage.fillAmount = 1 - (nextFire - Time.time) / cooldownValue;

        float red = (nextFire - Time.time) / cooldownValue;
        float green = 1 - (nextFire - Time.time) / cooldownValue;
        float blue = 0.35f;
        cooldownImage.color = new Color(red, green, blue);
    }

}
