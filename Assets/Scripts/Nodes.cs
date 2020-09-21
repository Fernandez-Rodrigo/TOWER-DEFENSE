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

    public bool isUpgraded = false;

    public TurretBlueprint turretBlueprint;

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


        BuildTorret(buildManager.GetTurretToBuild());
        

    }



    public Vector3 GetBuildPosition()
    {
        positionOffset = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        if (buildManager.turretToBuild.prfabTurret != buildManager.firePrefab)
        {
            
            return transform.position;
        }
        else
        {
            return positionOffset;
        }
    }




    public void BuildTorret (TurretBlueprint blueprint)
    {
        if (blueprint == null)
        {
            return;
        }
        else
        {

            if (PlayerStats.money < blueprint.cost)
            {
                return;
            }
            else
            {
                PlayerStats.money -= blueprint.cost;

                GameObject _turret = Instantiate(blueprint.prfabTurret, GetBuildPosition(), Quaternion.identity);
                turret = _turret;

                turretBlueprint = blueprint;

                GameObject effect = Instantiate(blueprint.effectBuild, GetBuildPosition(), Quaternion.identity);
                Destroy(effect, 4.5f);
            }
        }
    }

    public void UpgradeTurret()
    {
        
      
    

            if (PlayerStats.money < turretBlueprint.upgradeCost)
            {
                return;
            }
            else if(isUpgraded == false && PlayerStats.money >= turretBlueprint.upgradeCost)
            {
                PlayerStats.money -= turretBlueprint.upgradeCost;

            

            Destroy(turret);

                GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, transform.position, Quaternion.identity);
                turret = _turret;

            isUpgraded = true;

                GameObject effect = Instantiate(turretBlueprint.effectBuild, transform.position, Quaternion.identity);
                Destroy(effect, 4.5f);
            return;
            }


        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            return;
        } else if (isUpgraded == true && PlayerStats.money >= turretBlueprint.upgradeCost && turretBlueprint.canUpgrade2 == true)
        {
            PlayerStats.money -= turretBlueprint.upgradeCost;



            Destroy(turret);

            GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab2, transform.position, Quaternion.identity);
            turret = _turret;

            isUpgraded = true;

            this.turretBlueprint.canUpgrade2 = false;

            GameObject effect = Instantiate(turretBlueprint.effectBuild, transform.position, Quaternion.identity);
            Destroy(effect, 4.5f);
        }
        
    }

}
