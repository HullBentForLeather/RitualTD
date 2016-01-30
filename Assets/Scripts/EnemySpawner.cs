using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {


    public GameObject enemyPrefab;
    List<GameObject> enemies = new List<GameObject>();

    bool waveStarted = false;

    int spawnCount;
    int numSpawned;
    float startDelay = 0;
    float spawnDelay = 1f;
    float lastSpawn = 0;
    float waveStartTime = 0;

    Color color = Color.white;

    public PathNode startNode;

    // Use this for initialization
    void Start ()
    {
        waveStarted = false;
	}
	
    public void StartWave(int count, float delay, float spawnrate, Color color)
    {
        spawnCount = count;
        numSpawned = 0;

        startDelay = delay;
        spawnDelay = spawnrate;
        lastSpawn = 0;
        waveStartTime = Time.time;

        waveStarted = true;

        this.color = color;


    }


	// Update is called once per frame
	void Update ()
    {
        if (waveStarted)
        {
            if (numSpawned >= spawnCount)
            {
                waveStarted = false;
            }
            else
            {
                if (Time.time > waveStartTime + startDelay)
                {
                    if (Time.time > lastSpawn + spawnDelay)
                    {
                        // spawn enemy here
                        GameObject newItem = Instantiate(enemyPrefab);
                        newItem.transform.position = transform.position;


                        EnemyScript enemyScript = newItem.GetComponent<EnemyScript>();


                        enemyScript.SetStartNode(startNode);

                        enemyScript.GetComponentInChildren<Renderer>().material.color = color;

                        enemies.Add(newItem);

                        lastSpawn = Time.time;
                        ++numSpawned;
                    }
                }
            }
        }



	}
}
