using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSpawner : MonoBehaviour
{
    public GameObject zombPrefab;
    private float minSpawnRate = 1f;
    private float maxSpawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnZomb", Random.Range(minSpawnRate, maxSpawnRate));
    }

    void SpawnZomb()
    {
        GameObject zomb = Instantiate(zombPrefab, new Vector3(Random.Range(-74, 74), 0.15f, Random.Range(-74, 74)), transform.rotation);
        Invoke("SpawnZomb", Random.Range(minSpawnRate, maxSpawnRate));
    }
}
