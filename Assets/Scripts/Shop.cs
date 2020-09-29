using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (EventSystem.current.IsPointerOverGameObject())
            buildManager.SetTurretToBuild(gunTower);
    }
    public void SelectMachineGun()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            buildManager.SetTurretToBuild(mgunTower);
    }
    public void SelectLaserGun()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            buildManager.SetTurretToBuild(laserTower);
    }
    public void SelectRocket()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            buildManager.SetTurretToBuild(rocketTower);
    }
    public void SelectFireGun()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            buildManager.SetTurretToBuild(fireTower);

    }
}
