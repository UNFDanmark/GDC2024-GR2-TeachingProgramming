using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    private float leftoverCooldown;
    public float spawnCooldown;
    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        leftoverCooldown = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        leftoverCooldown = leftoverCooldown - Time.deltaTime;
        if (leftoverCooldown <= 0)
        {
            float xSpawn = Random.Range(xMin, xMax);
            float zSpawn = Random.Range(zMin, zMax);
            Vector3 spawnPoint = new Vector3(xSpawn, transform.position.y, zSpawn);
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            leftoverCooldown = spawnCooldown;
        }
    }
}
