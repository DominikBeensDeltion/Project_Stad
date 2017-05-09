using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public UIManager uim;

    public int currentWave;
    public int nextWave;

    public int maxEnemiesToSpawn;
<<<<<<< HEAD
    public int currentAmountOfEnemies;
=======
    public int currentSpawnedEnemies;
>>>>>>> origin/master
    public int enemySpawnInterval;

    public float nextWaveCountDown = 120f;
    public bool canCountDown;

    public bool canSpawn;
    public bool spawnEnemy;

    public bool inWave;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> emmies = new List<GameObject>();

    public float timeToNextWave;
    public Vector2 spawnPosOne;

    public Vector2 spawnPosTwo;

    public void StartCountDown()
    {
        if (nextWave == 1)
        {
            nextWaveCountDown = timeToNextWave;
        }
        else
        {
            nextWaveCountDown = 120f;
        }

        canCountDown = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            GameObject[] ems = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject g in ems)
            {
                Destroy(g);
            }
        }
        if (canCountDown)
        {
            nextWaveCountDown -= Time.deltaTime;

            if (nextWaveCountDown <= 0)
            {
                inWave = true;
                canCountDown = false;
                canSpawn = true;
                spawnEnemy = true;
                nextWaveCountDown = 0;
                nextWave++;
                currentWave++;
            }
        }

        if (canSpawn)
        {
<<<<<<< HEAD
            if (currentAmountOfEnemies < maxEnemiesToSpawn)
=======
            if (currentSpawnedEnemies < maxEnemiesToSpawn)
>>>>>>> origin/master
            {
                StartCoroutine(SpawnEnemies());
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
<<<<<<< HEAD
        if (inWave)
        {
            canSpawn = false;
            float x = Random.value;
=======
        canSpawn = false;
        float x = Random.value;

        if (x > 0.5)
        {
            int i = Random.Range(0, enemies.Count);
            Instantiate(enemies[i], spawnPosOne, Quaternion.identity);
            currentSpawnedEnemies++;
        }
        else if (x <= 0.5)
        {
            int i = Random.Range(0, enemies.Count);
            Instantiate(enemies[i], spawnPosTwo, Quaternion.identity);
            currentSpawnedEnemies++;
        }                 
>>>>>>> origin/master

            if (x > 0.5)
            {
                int i = Random.Range(0, enemies.Count);
                Instantiate(enemies[i], spawnPosOne, Quaternion.identity);
                currentAmountOfEnemies++;
            }
            else if (x <= 0.5)
            {
                int i = Random.Range(0, enemies.Count);
                Instantiate(enemies[i], spawnPosTwo, Quaternion.identity);
                currentAmountOfEnemies++;
            }

            yield return new WaitForSeconds(enemySpawnInterval);
            canSpawn = true;
        }
        
    }

    public void EndWave()
    {
        //WARNING BUG als je de eerste enemy killed voordat de 2e spawned end de wave
        GameObject[] currentEms = GameObject.FindGameObjectsWithTag("Enemy");
        if (currentEms.Length <= 0)
        {
            inWave = false;
            canCountDown = true;
            nextWaveCountDown = timeToNextWave;
            currentAmountOfEnemies = 0;
        }           
    }
}
