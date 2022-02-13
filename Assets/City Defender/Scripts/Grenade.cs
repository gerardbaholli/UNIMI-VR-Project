using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public void TriggerEffect()
    {
        Enemy[] enemyList = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemyList)
        {
            enemy.InflictDamage(5f);
        }
    }

}
