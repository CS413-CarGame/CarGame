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
        }
        if (other.gameObject.CompareTag("TNT"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("HealthBoost"))
        {
            Destroy(other.gameObject);
        }
    }
}
