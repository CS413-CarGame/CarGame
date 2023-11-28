using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZomb : MonoBehaviour
{
    static public int killedCount = 0;
    public AudioSource audioPlayer;
    public ParticleSystem deathEffect;

    private void OnTriggerEnter(Collider other)
    {
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
