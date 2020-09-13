using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int health = 1000;
    private Transform target;
    private int wayPointOrder = 0;
    public int dropMoney = 20;
    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(target.position, transform.position) < 0.2f)
        {
            GetNextWaypoint();
            return;
        }

    }


    void GetNextWaypoint()
    {
        if(wayPointOrder >= WayPoints.wayPoints.Length - 1)
        {

            LoseLives();
            return;
        }


        wayPointOrder++;
        target = WayPoints.wayPoints[wayPointOrder];
    }


    void LoseLives()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }


    public void TakeDamage(int ammount)
    {
        health -= ammount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.money += dropMoney;
        Destroy(gameObject);

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
    }

}
