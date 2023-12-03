using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Update and Set Health bar

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // Set max health value
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
