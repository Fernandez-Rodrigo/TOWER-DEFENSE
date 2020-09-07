using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int wayPointOrder = 0;


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
            Destroy(gameObject);
            return;
        }


        wayPointOrder++;
        target = WayPoints.wayPoints[wayPointOrder];
    }
}
