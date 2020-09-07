using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void PurchaseBasiqueGun()
    {
        buildManager.SetTurretToBuild(buildManager.basicTurretPrefab);
    }
    public void PurchaseMachineGun()
    {
        buildManager.SetTurretToBuild(buildManager.machineGunPregab);
    }
    public void PurchaseLaserGun()
    {
        buildManager.SetTurretToBuild(buildManager.laserPrefab); 
    }
    public void PurchaseRocket()
    {
        buildManager.SetTurretToBuild(buildManager.rocketLauncherPrefab); 
    }
    public void PurchaseFireGun()
    {
        buildManager.SetTurretToBuild(buildManager.firePrefab);
    }

}
