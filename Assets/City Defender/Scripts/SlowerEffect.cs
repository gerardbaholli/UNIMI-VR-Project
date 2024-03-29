using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerEffect : Effect
{
    [SerializeField] float slowerTime = 5f;
    [SerializeField] [Range(0.1f, 1f)] float slowerEffect = 0.5f;

    public void TriggerEffect()
    {
        Enemy[] enemyList = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemyList)
        {
            enemy.SetSpeed(enemy.GetSpeed() * slowerEffect);
        }

        StartCoroutine(RestoreSpeed(enemyList));
    }

    private IEnumerator RestoreSpeed(Enemy[] enemyList)
    {
        yield return new WaitForSeconds(slowerTime);

        foreach (Enemy enemy in enemyList)
        {
            enemy.SetSpeed(enemy.GetSpeed() / slowerEffect);
        }
    }

}
