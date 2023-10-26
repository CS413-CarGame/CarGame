using UnityEngine;

public class Zomb : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private float speed = 1.5f;

    public AudioSource audioPlayer;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Car.POS, speed * Time.deltaTime);
        transform.forward = Car.POS - transform.position;

        audioPlayer.Play();
    }
}
