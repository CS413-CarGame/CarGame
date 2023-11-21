using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Zomb"))
        {
            Destroy(other.gameObject);
            mainSpawner.canSpawnZomb = true;
        }
        if (other.gameObject.CompareTag("TNT"))
        {
            Destroy(other.gameObject);
            mainSpawner.canSpawnBomb = true;
        }
        if (other.gameObject.CompareTag("HealthBoost"))
        {
            Destroy(other.gameObject);
            mainSpawner.canSpawnHealth = true;
        }
    }
}
