using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{

    [SerializeField] int originalLife;

    private int currentLife;

    private void Start()
    {
        currentLife = originalLife;
    }

    public int GetCurrentLife()
    {
        return currentLife;
    }

    public void ApplyDamage(int damageValue)
    {
        currentLife -= damageValue;
    }

}
