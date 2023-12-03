using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Play main game audio

public class MainGameAudio : MonoBehaviour
{

    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
