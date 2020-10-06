using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Waves[] waves;

    public Transform enemyPrefab;

    public Transform enemyPrefab2;

    public Transform enemyPrefab3;

    public float timeBewteenWave = 10f;

    private float countdown = 10f;

    private int waveNumber = 0;

    public Text countDownText;

    public GameManager gameManager;

    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }


        if (waveNumber == waves.Length && PlayerStats.Lives > 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        {

            if (countdown <= 0)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBewteenWave;
            }

            countdown -= Time.deltaTime;

        }

       

    }


    IEnumerator SpawnWave()
    {
        Waves wave = waves[waveNumber];

        enemiesAlive = wave.countEnemy;

        for (int i = 0; i < wave.countEnemy; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1 / wave.rate);
        }

        PlayerStats.rounds++;
        waveNumber++;

     

    }


    void SpawnEnemy(GameObject enemy)
    {


        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        


    }
}
