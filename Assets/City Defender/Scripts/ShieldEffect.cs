using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : Effect
{

    [SerializeField] float shieldDuration = 2.5f;

    public void TriggerEffect()
    {
        FindObjectOfType<CameraShield>().ActivateShield(shieldDuration);
    }

}
