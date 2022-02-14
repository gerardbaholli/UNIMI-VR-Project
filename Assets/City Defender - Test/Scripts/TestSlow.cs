using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlow : MonoBehaviour
{

    [SerializeField] float slowerTime = 5f;
    [SerializeField] [Range(0.1f, 1f)] float slowerEffect = 0.5f;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            TriggerEffect();
    }

    public void TriggerEffect()
    {
        TestEnemy[] enemyList = FindObjectsOfType<TestEnemy>();

        foreach (TestEnemy enemy in enemyList)
        {
            enemy.SetSpeed(enemy.GetSpeed() * slowerEffect);
        }

        StartCoroutine(RestoreSpeed(enemyList));
    }

    private IEnumerator RestoreSpeed(TestEnemy[] enemyList)
    {
        yield return new WaitForSeconds(slowerTime);
        
        foreach (TestEnemy enemy in enemyList)
        {
            enemy.SetSpeed(enemy.GetSpeed() / slowerEffect);
        }
    }


}
