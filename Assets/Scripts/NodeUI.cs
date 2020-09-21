using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Nodes target;

    public GameObject ui;

    public Text upgradeText;

    public Text sellText;

    public Button upgradeButton;

    public TurretBlueprint turretBlueprint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Hide();
        }
    }


    public void SetTarget(Nodes _target)
    {
        target = _target;

        transform.position = target.transform.position;

        ui.SetActive(true);

        if (target.isUpgraded == false || turretBlueprint.canUpgrade2 == true)
        {
            upgradeText.text = "UPGRADE   $: " + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeText.text = "MAX UPGRADE";
            upgradeButton.interactable = false;
        }
        sellText.text ="SELL $:"+ target.turretBlueprint.sellValue.ToString();

    }

    public void Hide()
    {
        ui.SetActive(false);
    }


    public void Upgrade()
    {
        target.UpgradeTurret();
     
    }
}
