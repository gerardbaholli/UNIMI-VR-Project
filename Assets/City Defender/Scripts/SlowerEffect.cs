using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerEffect : Effect
{
    public void TriggerEffect()
    {
        Enemy[] enemyList = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemyList)
        {
            enemy.SetSpeed(enemy.GetSpeed() / 2);
        }

        StartCoroutine(RestoreSpeed(enemyList));
    }

    private IEnumerator RestoreSpeed(Enemy[] enemyList)
    {
        yield return new WaitForSeconds(5f);

        foreach (Enemy enemy in enemyList)
        {
            enemy.SetSpeed(enemy.GetSpeed() * 2);
        }
    }

}
