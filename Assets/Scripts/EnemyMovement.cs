using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wayPointOrder = 0;
    public bool isRunning = true;
    public Animator animatorMob;

    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.wayPoints[0];
        animatorMob = GetComponent<Animator>();
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) < 0.2f)
        {
            GetNextWaypoint();
            transform.LookAt(target);
            return;
        }

        enemy.speed = enemy.startSpeed;

        animatorMob.SetBool("isRunning",isRunning);
    }


    void GetNextWaypoint()
    {
        if (wayPointOrder >= WayPoints.wayPoints.Length - 1)
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
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

  

    

}
