using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] Enemy enemy;
    [SerializeField] float spawnCooldown;

    private GameStatus gameStatus;
    private Nexus nexus;
    private bool isCoroutineStarted = false;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void FixedUpdate()
    {
        if (!gameStatus.IsGameStarted())
        {
            return;
        }

        if (!isCoroutineStarted)
        {
            isCoroutineStarted = true;
            nexus = FindObjectOfType<Nexus>();
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        Instantiate(enemy, gameObject.transform.position,
            Quaternion.LookRotation(nexus.transform.position - gameObject.transform.position));

        yield return new WaitForSeconds(spawnCooldown);

        StartCoroutine(SpawnEnemies());
    }

    public bool IsTargetAlive()
    {
        return (nexus != null) ? true : false;
    }

}
