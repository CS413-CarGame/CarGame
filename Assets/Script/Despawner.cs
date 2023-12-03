using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entity despawner

public class Despawner : MonoBehaviour
{
    // Destroy and respawn entity if spawn within despawn zone
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
        if (other.gameObject.CompareTag("bombZomb"))
        {
            Destroy(other.gameObject);
            mainSpawner.canSpawnBombZomb = true;
        }
    }
}
