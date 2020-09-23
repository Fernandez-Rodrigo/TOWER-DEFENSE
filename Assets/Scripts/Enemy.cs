using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 5f;
    public float speed;
    public float health = 1000;
    
    
    public int dropMoney = 50;
    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
      
    }


   


    public void TakeDamage(float ammount)
    {
        health -= ammount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float value)
    {
        speed = startSpeed * value;
    }

    private void Die()
    {
        PlayerStats.money += dropMoney;

        WaveSpawner.enemiesAlive--;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        Destroy(gameObject);
    }

}
