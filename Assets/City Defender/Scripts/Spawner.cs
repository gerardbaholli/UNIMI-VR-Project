using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemyList;
    [SerializeField] float startingSpawnCooldown = 5f;
    [SerializeField] [Range(0.001f, 0.2f)] float decreasingAmount = 0.05f;
    [SerializeField] float minSpawnCooldown = 0.3f;

    private GameStatus gameStatus;
    private Nexus nexus;
    private bool isCoroutineStarted = false;
    private int numberOfEnemy;
    public float spawnCooldown;

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
        float xPos = Random.Range(6, 13) * side[Random.Range(0, 2)];
        float yPos = Random.Range(1, 10);
        float zPos = Random.Range(6, 13) * side[Random.Range(0, 2)];
        Vector3 spawnPosition = new(xPos, yPos, zPos);
        Debug.Log(spawnPosition);


        Enemy enemy = enemyList[Random.Range(0, numberOfEnemy - 1)];
        Debug.Log(enemy.name);

        Instantiate(enemy, gameObject.transform.position + spawnPosition,
        Quaternion.LookRotation(nexus.transform.position - spawnPosition));

        DecreaseSpawnCooldown(decreasingAmount);
        Debug.Log("Cooldown: " + spawnCooldown);

        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SpawnEnemies());
    }

    private void DecreaseSpawnCooldown(float value)
    {
        if ((spawnCooldown - value) <= minSpawnCooldown)
        {
            spawnCooldown = minSpawnCooldown;
        }
        else
        {
            spawnCooldown -= value;
        }
    }

    public void SetSpawnCooldown(float value)
    {
        spawnCooldown = value;
    }

    public float GetSpawnCooldown()
    {
        return spawnCooldown;
    }

}
