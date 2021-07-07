using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        StartCoroutine(PowerupSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PowerupSpawnRoutine()
    {
        float  seconds = GenerateSpawnTime();
        yield return new WaitForSeconds(seconds);
        SpawnPowerup();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float SpawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, SpawnPosZ);

        return randomPos;
    }

    private float GenerateSpawnTime()
    {
        float timeToSpawn = Random.Range(10, 30);

        return timeToSpawn;
    }

    private void SpawnPowerup()
    {
        while(GameObject.FindGameObjectWithTag("Powerup") == null)
        {
            bool powerupOnPlayer = GameObject.Find("Player").GetComponent<PlayerController>().hasPowerup;
            Debug.Log("Has PowerUp: "+ powerupOnPlayer);
            if(powerupOnPlayer == false)
            {
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            }            
        }
        StartCoroutine(PowerupSpawnRoutine());
    }
}
