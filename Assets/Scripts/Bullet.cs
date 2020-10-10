using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 50f;

    public GameObject impactEffect;

    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            Damage(target);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void Seek (Transform _target)
    {
        target = _target;
    }


    public void HitTarget()
    {
        GameObject effectHit = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectHit, 1f);
        this.GetComponent<Bullet>().enabled = false;

        Destroy(gameObject, 0.5f);
        return;
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();


        if (e != null)
        {
            e.TakeDamage(damage);
            return;
        }
    }
}
