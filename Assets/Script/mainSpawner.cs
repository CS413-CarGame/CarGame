using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSpawner : MonoBehaviour
{
    public GameObject zombPrefab;
    public GameObject TntPrefab;
    public GameObject HealthPrefab;
    public GameObject bombZombPrefab;

    private float minSpawnRate = 1f;
    private float maxSpawnRate = 3f;
    private float minBomberSpawnRate = 7f;
    private float maxBomberSpawnRate = 13f;
    private float minPowerSpawn = 15f;
    private float maxPowerSpawn = 30f;

    public static bool canSpawnZomb = false;
    public static bool canSpawnHealth = false;
    public static bool canSpawnBomb = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnZomb", Random.Range(minSpawnRate, maxSpawnRate));
        Invoke("SpawnBomb", Random.Range(minPowerSpawn, maxPowerSpawn));
        Invoke("SpawnHealth", Random.Range(minPowerSpawn, maxPowerSpawn));
        Invoke("SpawnBombZomb", Random.Range(minPowerSpawn, maxPowerSpawn));
        /*
        if (Ramp.canSpawnRamp && Input.GetKeyDown("space"))
        {
            Invoke("SpawnRamp", Random.Range(minPowerSpawn, maxPowerSpawn));         
        }
        */
    }

    private void Update()
    {
        if (canSpawnZomb)
        {
            Invoke("SpawnZomb", 0);
            canSpawnZomb = false;
        }
        if (canSpawnHealth)
        {
            Invoke("SpawnBomb", 0);
            canSpawnHealth = false;
        }
        if (canSpawnBomb)
        {
            Invoke("SpawnHealth", 0);
            canSpawnBomb = false;
        }
    }

    void SpawnZomb()
    {
        GameObject zomb = Instantiate(zombPrefab, new Vector3(Random.Range(-74, 74), 0.15f, Random.Range(-74, 74)), transform.rotation);
        Invoke("SpawnZomb", Random.Range(minSpawnRate, maxSpawnRate));
    }

    void SpawnBombZomb()
    {
        GameObject bombZomb = Instantiate(bombZombPrefab, new Vector3(Random.Range(-74, 74), 0.15f, Random.Range(-74, 74)), transform.rotation);
        Invoke("SpawnBombZomb", Random.Range(minBomberSpawnRate, maxBomberSpawnRate));
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

    /*
    void SpawnRamp()
    {
        if( Ramp.canSpawnRamp && Input.GetKeyDown("space"))
        {
            GameObject ramp = Instantiate(HealthPrefab, new Vector3(Random.Range(-24, 24), 2f, Random.Range(-24, 24)), transform.rotation);
            Invoke("SpawnRamp", Random.Range(minPowerSpawn, maxPowerSpawn));
            Ramp.canSpawnRamp = false;
        }

    }
    */
}
