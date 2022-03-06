using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemies Prefab")]
    [SerializeField] Enemy[] enemyList;
    [SerializeField] float minSpawnCooldown = 1f;

    [Header("Boss Prefab")]
    [SerializeField] Enemy boss;
    [SerializeField] float bossSpawnCooldown = 60f;

    [Header("Log Spawn Function")]
    [SerializeField] float logBase = 0.5f;
    [SerializeField] float logPlus = 9.8f;

    private GameStatus gameStatus;
    private Nexus nexus;
    private bool isCoroutineStarted = false;
    private int numberOfEnemy;
    private float spawnCooldown;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        numberOfEnemy = enemyList.Length;
        spawnCooldown = minSpawnCooldown + 10f;
    }

    private void FixedUpdate()
    {
        if (!gameStatus.IsGameStarted())
            return;

        if (isCoroutineStarted)
            return;

        isCoroutineStarted = true;
        nexus = FindObjectOfType<Nexus>();
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnBoss());
    }

    private IEnumerator SpawnEnemies()
    {
        int[] side = { -1, 1 };
        float xPos = Random.Range(7, 13) * side[Random.Range(0, 2)];
        float yPos = Random.Range(1, 15);
        float zPos = Random.Range(7, 13) * side[Random.Range(0, 2)];
        Vector3 spawnPosition = new(xPos, yPos, zPos);


        Enemy enemy = enemyList[Random.Range(0, numberOfEnemy)];

        Instantiate(enemy, gameObject.transform.position + spawnPosition,
        Quaternion.LookRotation(nexus.transform.position - spawnPosition));

        LogarithmicUpdateCooldown(logBase, logPlus);
        //Debug.Log("Cooldown: " + spawnCooldown);

        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(bossSpawnCooldown);

        int[] side = { -1, 1 };
        float xPos = Random.Range(7, 13) * side[Random.Range(0, 2)];
        float yPos = Random.Range(1, 15);
        float zPos = Random.Range(7, 13) * side[Random.Range(0, 2)];
        Vector3 spawnPosition = new(xPos, yPos, zPos);

        Instantiate(boss, gameObject.transform.position + spawnPosition,
        Quaternion.LookRotation(nexus.transform.position - spawnPosition));

        StartCoroutine(SpawnBoss());
    }

    private void LogarithmicUpdateCooldown(float logBase, float logPlus)
    {
        if (spawnCooldown < minSpawnCooldown)
            return;

        spawnCooldown = Mathf.Log(Time.time + 1, logBase) + logPlus;
    }

}
