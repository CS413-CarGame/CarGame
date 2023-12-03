using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Play main menu music

public class MainMenuMusic : MonoBehaviour
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