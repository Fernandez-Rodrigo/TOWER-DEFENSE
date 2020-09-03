using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    public float range = 15f;

    public Transform partToRotate;

    public float fireRate = 1f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortDistance <= range)
        {
            target = closestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }



        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x-90, rotation.y, 0f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
