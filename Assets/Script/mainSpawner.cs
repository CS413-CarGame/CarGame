using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSpawner : MonoBehaviour
{
    public GameObject zombPrefab;
    public GameObject TntPrefab;
    public GameObject HealthPrefab;
    private float minSpawnRate = 1f;
    private float maxSpawnRate = 5f;
    private float minPowerSpawn = 15f;
    private float maxPowerSpawn = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnZomb", Random.Range(minSpawnRate, maxSpawnRate));
        Invoke("SpawnBomb", Random.Range(minPowerSpawn, maxPowerSpawn));
        Invoke("SpawnHealth", Random.Range(minPowerSpawn, maxPowerSpawn));
    }

    void SpawnZomb()
    {
        GameObject zomb = Instantiate(zombPrefab, new Vector3(Random.Range(-74, 74), 0.15f, Random.Range(-74, 74)), transform.rotation);
        Invoke("SpawnZomb", Random.Range(minSpawnRate, maxSpawnRate));
    }

    void SpawnBomb()
    {
        GameObject Tnt = Instantiate(TntPrefab, new Vector3(Random.Range(-24, 24), 2f, Random.Range(-24, 24)), transform.rotation);
        Invoke("SpawnBomb", Random.Range(minPowerSpawn, maxPowerSpawn));
    }

    void SpawnHealth()
    {
        GameObject HpBoost = Instantiate(HealthPrefab, new Vector3(Random.Range(-24, 24), 2f, Random.Range(-24, 24)), transform.rotation);
        Invoke("SpawnHealth", Random.Range(minPowerSpawn, maxPowerSpawn));
    }
}
