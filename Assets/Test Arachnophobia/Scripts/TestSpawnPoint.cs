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
            StartCoroutine(SpawnEnemies());
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

    private IEnumerator SpawnEnemies()
    {
        Instantiate(enemy, gameObject.transform.position,
            Quaternion.LookRotation(nexus.transform.position - gameObject.transform.position));

        yield return new WaitForSeconds(spawnCooldown);

        StartCoroutine(SpawnEnemies());
    }

}
