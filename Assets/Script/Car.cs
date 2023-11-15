using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    static public Vector3 POS = Vector3.zero;
    static public Vector3 TRUCKVEL = Vector3.zero;
    public HealthBar healthBar;
    public int ZombDamage = 7;
    public int WallDamageMult = 10;
    //public int TntDamage = 30;
    public int HealthAdd = -50;
    public int HEALTH;
    public int maxHealth = 100;
    //public RampBuild Ramp;

    void Start()
    {
        HEALTH = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (CheckForDeath(HEALTH))
        {
            ScoreManager.instance.SaveHighScore();
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void FixedUpdate()
    {
        //UnityEngine.Debug.Log(rb.velocity.magnitude);
        TRUCKVEL = rb.velocity;
        Vector3 tPos = transform.position;
        POS = tPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zomb"))
        {
            if (TRUCKVEL.magnitude <= 4.5)
            {
                TakeDamage(ZombDamage);
            }
        }

        if (other.gameObject.CompareTag("bombZomb"))
        {
            TakeDamage(15);
        }

        if (other.gameObject.CompareTag("Arena"))
        {
            if (TRUCKVEL.magnitude >= 3.5)
            {
                TakeDamage(WallDamageMult);
            }
        }
        if (other.gameObject.CompareTag("TNT"))
        {
            TakeDamage(30);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HealthBoost"))
        {
            if((HEALTH - -20) > 100)
            {
                TakeDamage(HEALTH - 100);
            }
            else
            {
                TakeDamage(-20);
            }
            //Ramp.canSpawnRamp = true;
            Destroy(other.gameObject);
            
        }


    }

    bool CheckForDeath(int health)
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }

    void TakeDamage(int damage)
    {
        HEALTH -= damage;
        Debug.Log(HEALTH);
        healthBar.SetHealth(HEALTH);
    }
}
