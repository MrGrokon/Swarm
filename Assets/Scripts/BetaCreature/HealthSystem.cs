using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
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

    public void Heal(int healAmount)
    {
        healthPoint += healAmount;
    }

    private void Die()
    {
        PackManager.packInstance.Remove_PackMember(this.gameObject);
    }
}
