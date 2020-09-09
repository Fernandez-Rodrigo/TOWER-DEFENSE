using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public TurretBlueprint turretToBuild;

    public GameObject basicTurretPrefab;
    public GameObject machineGunPregab;
    public GameObject rocketLauncherPrefab;
    public GameObject laserPrefab;
    public GameObject firePrefab;

    public bool CanBuid
    {
        get { return turretToBuild != null; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }


    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Nodes node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            return;
        }
        else
        {
            PlayerStats.money -= turretToBuild.cost;
        }
              
        {
            GameObject turret = Instantiate(turretToBuild.prfabTurret, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
        }
    }


}
