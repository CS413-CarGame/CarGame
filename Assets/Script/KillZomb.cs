using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kill Zombie script

public class KillZomb : MonoBehaviour
{
    static public int killedCount = 0;
    public AudioSource audioPlayer;
    public ParticleSystem deathEffect;

    // Collision Detection
    private void OnTriggerEnter(Collider other)
    {
        // If car hits zombie going fastter than a certain speed, kill zombie
        if (other.gameObject.CompareTag("Zomb") || other.gameObject.CompareTag("bombZomb"))
        {
            if(Car.TRUCKVEL.magnitude >= 2.5)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);

                Destroy(other.gameObject);

                ScoreManager.instance.AddScore(100);

                audioPlayer.Play();

                killedCount++;
                Debug.Log(killedCount.ToString());
            }
        }
    }
}
