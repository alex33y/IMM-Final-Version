using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int enemySpawnCount;
    public int waveCounter = 1;
    public float waveTimer = 5f;
    public int enemyCount;
    private bool canMove = false;

     void SpawnEnemyWave(int enemySpawnCount){
        for(int i = 0; i < enemySpawnCount; i++){
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int randomRangeSpawnX = Random.Range(-10, 10);
            int randomRangeSpawnZ = (Random.Range(-1,1)) * 10; // preventing the playerObject from getting immediately destroyed
            // enemies will spawn randomly along an x axis, but will spawn at either the top x-axis or the bottom x-axis of the map

            if (randomRangeSpawnZ == 0) {
                randomRangeSpawnZ = (randomRangeSpawnZ + 1) * 10;
            } // this fixes the random.range so if it picks 0 it changes it to 1
            
            
            Instantiate(enemyPrefabs[enemyIndex], new Vector3(randomRangeSpawnX, 1, randomRangeSpawnZ), 
            enemyPrefabs[enemyIndex].transform.rotation ); 
            }
    } 
    
    void Start()
    {

    }

    void Update()
    {
        if(canMove == true){
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0) {
                waveTimer -= Time.deltaTime;

                if (waveTimer <= 0){
                     waveCounter++; 
                     SpawnEnemyWave(waveCounter);
                     waveTimer = 5f;
                  }
                
            }      
        }
    }

    public void EnableMovement(){
        canMove = true;
    }

    public void DisableMovement(){
        canMove = false;
    }
}
