using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform enemyPrefab2;

    public Transform enemyPrefab3;

    public float timeBewteenWave = 10f;

    private float countdown = 2f;

    private int waveNumber = 0;

    public Text countDownText;

    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBewteenWave;
        }

        countdown -= Time.deltaTime;


    }


    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveNumber++;
        PlayerStats.rounds++;
    }


    void SpawnEnemy()
    {

        if (waveNumber <= 5)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        if(waveNumber > 5 && waveNumber <= 10)
        {
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
        if(waveNumber > 10 && waveNumber<= 20)
        {
            Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
