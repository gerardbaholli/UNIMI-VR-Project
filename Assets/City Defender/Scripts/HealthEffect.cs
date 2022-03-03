using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEffect : Effect
{
    public void TriggerEffect()
    {
        Nexus nexus = FindObjectOfType<Nexus>();

        var newLife = nexus.GetCurrentLife() * 1.2f;

        if (newLife <= nexus.GetOriginalLife())
            nexus.SetLife(newLife);
        else
            nexus.SetLife(nexus.GetOriginalLife());
    }

}
