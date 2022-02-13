using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] Enemy[] enemyList;
    [SerializeField] float spawnCooldown;

    private GameStatus gameStatus;
    private Nexus nexus;
    private bool isCoroutineStarted = false;
    private int numberOfEnemy;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        numberOfEnemy = enemyList.Length;
    }

    private void FixedUpdate()
    {
        if (!gameStatus.IsGameStarted())
            return;

        if (!isCoroutineStarted)
        {
            isCoroutineStarted = true;
            nexus = FindObjectOfType<Nexus>();
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        Enemy enemy = enemyList[Random.Range(0, numberOfEnemy)];
        Debug.Log(enemy.name);
        Instantiate(enemy, gameObject.transform.position,
        Quaternion.LookRotation(nexus.transform.position - gameObject.transform.position));

        yield return new WaitForSeconds(spawnCooldown);

        StartCoroutine(SpawnEnemies());
    }

    public bool IsTargetAlive()
    {
        return (nexus != null) ? true : false;
    }

    public void SetSpawnCooldown(float value)
    {
        spawnCooldown = value;
    }

    public float GetSpawnCooldown()
    {
        return spawnCooldown;
    }

    public void ChangeSpawnCooldown(float incresingPerc)
    {
        spawnCooldown *= incresingPerc;
    }

}
