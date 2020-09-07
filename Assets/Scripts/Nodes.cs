using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color nodeColor;

    private Color startColor;

    private GameObject turret;

    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        startColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        GetComponent<Renderer>().material.color = nodeColor;
    }

    private void OnMouseExit()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        GetComponent<Renderer>().material.color = startColor;
    }

    private void OnMouseDown()
    {
        Vector3 firePosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (buildManager.GetTurretToBuild() == null)
            return;

        if(turret != null)
        {
            return;
        }
        {
            GameObject turretToBuid = buildManager.GetTurretToBuild();
            if (turretToBuid == buildManager.firePrefab)
            {
                turret = Instantiate(turretToBuid, firePosition, transform.rotation);
            }
            else
            {
                turret = Instantiate(turretToBuid, transform.position, transform.rotation);
            }
        }
        
        
        

    }

}
