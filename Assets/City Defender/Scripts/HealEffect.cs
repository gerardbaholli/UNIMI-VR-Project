using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    [SerializeField] [Range(0f, 1f)] float healPercentage = 0.2f;

    public void TriggerEffect()
    {
        Nexus nexus = FindObjectOfType<Nexus>();

        float newLife = nexus.GetCurrentLife() + (nexus.GetCurrentLife() * healPercentage);

        if (newLife <= nexus.GetOriginalLife())
            nexus.SetLife(newLife);
        else
            nexus.SetLife(nexus.GetOriginalLife());
    }

}
