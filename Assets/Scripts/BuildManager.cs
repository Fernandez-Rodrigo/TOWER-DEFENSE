using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public TurretBlueprint turretToBuild;
    private Nodes selectedNode;
    public GameObject buildEffect;
    public NodeUI nodeUI;

    public GameObject basicTurretPrefab;
    public GameObject machineGunPregab;
    public GameObject rocketLauncherPrefab;
    public GameObject laserPrefab;
    public GameObject firePrefab;

    public bool CanBuid
    {
        get { return turretToBuild != null; }
    }

    public bool HasMoney
    {
        get { return PlayerStats.money >= turretToBuild.cost; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }


    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    public void BuildTurretOn(Nodes node)
    {
        if (turretToBuild == null)
        {
            return;
        }
        else
        {

            if (PlayerStats.money < turretToBuild.cost)
            {
                return;
            }
            else
            {
                PlayerStats.money -= turretToBuild.cost;

                GameObject turret = Instantiate(turretToBuild.prfabTurret, node.GetBuildPosition(), Quaternion.identity);
                node.turret = turret;

                GameObject effect = Instantiate(turretToBuild.effectBuild, node.GetBuildPosition(), Quaternion.identity);
                Destroy(effect, 4.5f);
            }
        }
              
        {
          
        }
    }


    public void SelectedNode(Nodes node)
    {
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

}
