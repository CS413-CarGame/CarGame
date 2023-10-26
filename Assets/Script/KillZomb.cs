using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZomb : MonoBehaviour
{
    public AudioSource audioPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zomb"))
        {
            if(Car.TRUCKVEL.magnitude >= 4.5)
            {
                Destroy(other.gameObject);

                ScoreManager.instance.AddScore(100);

                audioPlayer.Play();
            }
        }
    }
}
