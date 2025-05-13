using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;

    bool canSpawn = true;

    public float enemySpawnInterval;
    public float enemySpawnRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        if (!canSpawn) return;

        canSpawn = false;
        StartCoroutine(SpawnDelay());

        Vector3 spawnPos = transform.position + Random.insideUnitSphere * enemySpawnRadius;
        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
    }

    IEnumerator SpawnDelay()
    {
        enemySpawnInterval = Random.Range(1, 5);
        yield return new WaitForSeconds(enemySpawnInterval);
        canSpawn = true;
    }
}
