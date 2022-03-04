using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : Effect
{
    [SerializeField] float shieldDuration = 2.5f;

    public void TriggerEffect()
    {

    }

    private IEnumerator Shield()
    {

        yield return new WaitForSeconds(shieldDuration);

    }

}
