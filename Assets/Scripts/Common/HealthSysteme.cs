using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSysteme : MonoBehaviour
{
    [Range(15, 300)]
    public int MaxHealth = 50;

    private int _health;

    private void Awake() {
        _health = MaxHealth;
    }

    //Infliger des dommages
    public void TakeDamage(int _amount){
        _health -= _amount;
        if(_health<= 0){
            Die();
        }
    }

    //Donner de la vie
    public void Heal(int _amount){
        _health += _amount;
        if(_health > MaxHealth){
            _health = MaxHealth;
        }
    }

    private void Die(){
        Debug.Log(this.name + " Died");
        Destroy(this.gameObject);
    }
}
