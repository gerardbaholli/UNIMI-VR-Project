using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCD : MonoBehaviour
{

    private Cooldown cooldownUI;

    private void Start()
    {
        cooldownUI = FindObjectOfType<Cooldown>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cooldownUI.StartCooldown();
        }
    }

}
