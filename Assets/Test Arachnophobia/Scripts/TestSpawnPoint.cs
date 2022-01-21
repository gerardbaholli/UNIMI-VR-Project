using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnPoint : MonoBehaviour
{

    [SerializeField] TestEnemy enemy;
    [SerializeField] int enemyToSpawn;
    [SerializeField] float spawnCooldown;

    private TestNexus nexus;

    private void Start()
    {
        nexus = FindObjectOfType<TestNexus>();
        Debug.Log(nexus);

        if (nexus != null)
            StartCoroutine(Generate());
        else
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        
    }

    public bool IsTargetAlive()
    {
        return (nexus != null) ? true : false;
    }

    IEnumerator Generate()
    {
        while (enemyToSpawn > 0 && IsTargetAlive())
        {
            Instantiate(enemy, transform.position, Quaternion.LookRotation(nexus.transform.position - transform.position));
            yield return new WaitForSeconds(spawnCooldown);
            enemyToSpawn--;
        }
        
    }

}
