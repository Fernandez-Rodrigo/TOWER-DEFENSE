using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject basicTurretPrefab;
    public GameObject machineGunPregab;
    public GameObject rocketLauncherPrefab;
    public GameObject laserPrefab;
    public GameObject firePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }


    private void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }


}
