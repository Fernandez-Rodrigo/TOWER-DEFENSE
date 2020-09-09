using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint gunTower;
    public TurretBlueprint mgunTower;
    public TurretBlueprint laserTower;
    public TurretBlueprint rocketTower;
    public TurretBlueprint fireTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectBasiqueGun()
    {
        buildManager.SetTurretToBuild(gunTower);
    }
    public void SelectMachineGun()
    {
        buildManager.SetTurretToBuild(mgunTower);
    }
    public void SelectLaserGun()
    {
        buildManager.SetTurretToBuild(laserTower); 
    }
    public void SelectRocket()
    {
        buildManager.SetTurretToBuild(rocketTower); 
    }
    public void SelectFireGun()
    {
        buildManager.SetTurretToBuild(fireTower);
    }

}
