using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public int HEALTH;
    public int maxHealth = 100;

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
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("_Scene_1");
    }

    private void FixedUpdate()
    {
        UnityEngine.Debug.Log(rb.velocity.magnitude);
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
        if (other.gameObject.CompareTag("Arena"))
        {
            if (TRUCKVEL.magnitude >= 3.5)
            {
                TakeDamage(WallDamageMult);
            }
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
        healthBar.SetHealth(HEALTH);
    }
}
