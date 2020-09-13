using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;


    public Transform partToRotate;

    public GameObject bulletPrefab;

    public Transform firePoint;

    public bool useLaser = false;

    public LineRenderer lineRender;

    public ParticleSystem impactLasserEffect;

    public Light lightLasser;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;



   


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
            if(useLaser == true)
            {
                if(lineRender.enabled == true)
                {
                    lineRender.enabled = false;
                    impactLasserEffect.Stop();
                    lightLasser.enabled = false;
                }
            }

            return;
        }


        LockOnTarget();

        if (useLaser == true)
        {
            Laser();
        }
        else
        {


            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    public void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(this.transform.rotation.x - 90f, rotation.y, 0f);

    }


    public void Laser()
    {
        if(lineRender.enabled == false)
        {
            lineRender.enabled = true;
            impactLasserEffect.Play();
            lightLasser.enabled = true;
        }

        lineRender.SetPosition(0, firePoint.position);
        lineRender.SetPosition(1, target.position);

        Vector3 MobToLasser = firePoint.position - target.position;

        impactLasserEffect.transform.position = target.position + MobToLasser.normalized * 1f;

    }

    private void Shoot()
    {
        GameObject spawnBullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = spawnBullet.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
