using UnityEngine;

public class Zomb : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private float speed = 10f;

    private bool isCollidingWithCar = false;
    public AudioSource audioPlayer;
    public AudioSource audioPlayer1;
    public int randNum;


    private void Start()
    {
        int randNum = Random.Range(0, 2);

        Debug.Log(randNum);

        if (randNum == 0)
        {
            Debug.Log("play zombie noise1");
            audioPlayer.Play();
        }

        else
        {
            audioPlayer1.Play();
        }

    }

    private void Update()
    {
        if (!isCollidingWithCar)
        {
            MoveTowardsCenter();
        }
    }

    private void MoveTowardsCenter()
    {
        transform.position = Vector3.MoveTowards(transform.position, Car.POS, speed * Time.deltaTime);
        transform.forward = Car.POS - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            isCollidingWithCar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            isCollidingWithCar = false;
        }
    }
}
