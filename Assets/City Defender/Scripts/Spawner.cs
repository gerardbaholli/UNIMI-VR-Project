using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemyList;
    [SerializeField] float startingSpawnCooldown = 5f;
    [SerializeField] [Range(0.001f, 0.2f)] float decreasingAmount = 0.05f;
    [SerializeField] float minSpawnCooldown = 0.3f;

    [Header("Log Spawn Function")]
    [SerializeField] float logBase = 0.5f;
    [SerializeField] float logPlus = 10f;

    private GameStatus gameStatus;
    private Nexus nexus;
    private bool isCoroutineStarted = false;
    private int numberOfEnemy;
    private float spawnCooldown;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        numberOfEnemy = enemyList.Length;
        spawnCooldown = startingSpawnCooldown;
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
        Debug.Log("Cooldown: " + spawnCooldown);

        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SpawnEnemies());
    }

    private void LogarithmicUpdateCooldown(float logBase, float logPlus)
    {
        if (spawnCooldown < minSpawnCooldown)
            return;

        spawnCooldown = Mathf.Log(Time.time + 1, logBase) + logPlus;
    }

}
