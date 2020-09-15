using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int money;

    public int startMoney = 1500;

    public static int Lives;
    public int startLives = 20;
    public static int rounds;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        Lives = startLives;
        rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
