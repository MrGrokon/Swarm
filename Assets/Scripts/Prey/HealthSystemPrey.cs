using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemPrey : MonoBehaviour
{
    private int healthPoint;

    public void TakeDamage(int dmg)
    {
        healthPoint -= dmg;
        if (healthPoint <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        healthPoint += amount;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
