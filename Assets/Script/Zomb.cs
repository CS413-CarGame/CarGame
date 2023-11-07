using UnityEngine;

public class Zomb : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private float speed = 1.5f;

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
        transform.position = Vector3.MoveTowards(transform.position, Car.POS, speed * Time.deltaTime);
        transform.forward = Car.POS - transform.position;

       
        
        
        

    }
}
