using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color nodeColor;

    public Color noMoneyColor;

    private Color startColor;

    public GameObject turret;

    public Vector3 positionOffset;

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
       
        if (!buildManager.CanBuid)
            return;


        if (buildManager.HasMoney == true)
        {

            GetComponent<Renderer>().material.color = nodeColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = noMoneyColor;
        }
    }

    private void OnMouseExit()
    {
      

        
        GetComponent<Renderer>().material.color = startColor;
    }

    private void OnMouseDown()
    {
        Vector3 firePosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

       

        if (turret != null)
        {
            buildManager.SelectedNode(this);
        }


        buildManager.BuildTurretOn(this);
        

    }



    public Vector3 GetBuildPosition()
    { positionOffset = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        if (buildManager.turretToBuild.prfabTurret == buildManager.firePrefab)
        {
            return positionOffset;
        }
        else
        { return transform.position; }
    }

}
