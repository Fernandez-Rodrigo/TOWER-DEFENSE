using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Nodes target;

    public GameObject ui;

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
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
