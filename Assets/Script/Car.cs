using UnityEngine;
using UnityEngine.SceneManagement;

// Car Collision effects

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

    // zomb cooldown
    private bool canTakeZombDamage = true;
    private float zombDamageCooldown = 0.5f;

    // Set Values at start
    void Start()
    {
        HEALTH = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
    }

    // Check for player death every frame
    void Update()
    {
        if (CheckForDeath(HEALTH))
        {
            ScoreManager.instance.SaveHighScore();
            LoadMainMenu();
        }
    }

    // Load main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Get the truck velocity and position at a fixed rate
    private void FixedUpdate()
    {
        //UnityEngine.Debug.Log(rb.velocity.magnitude);
        TRUCKVEL = rb.velocity;
        Vector3 tPos = transform.position;
        POS = tPos;
    }

    // Collision Detection for car damage
    private void OnTriggerEnter(Collider other)
    {
        // Take car damage from zombie if traveling slower than a certain speed
        if (other.gameObject.CompareTag("Zomb"))
        {
            if (canTakeZombDamage && TRUCKVEL.magnitude <= 4.5)
            {
                TakeDamage(ZombDamage * (1 + KillZomb.killedCount / 10));
                canTakeZombDamage = false;
                Invoke("ResetZombDamageCooldown", zombDamageCooldown);
            }
        }

        // Take car damage when hitting a bomb zombie
        if (other.gameObject.CompareTag("bombZomb"))
        {
            TakeDamage(20);
        }

        // Take car damage when hitting a wall
        if (other.gameObject.CompareTag("Arena"))
        {
            if (TRUCKVEL.magnitude >= 3.5)
            {
                TakeDamage(WallDamageMult);
            }
        }

        // Take car damage when hitting TNT powerup
        if (other.gameObject.CompareTag("TNT"))
        {
            TakeDamage(30);
            Destroy(other.gameObject);
        }

        // Heal car when hitting health boost powerup
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

    // Check for player death
    bool CheckForDeath(int health)
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }

    void ResetZombDamageCooldown()
    {
        canTakeZombDamage = true;
    }

    // Take car damage
    void TakeDamage(int damage)
    {
        HEALTH -= damage;
        Debug.Log(HEALTH);
        healthBar.SetHealth(HEALTH);
    }
}
