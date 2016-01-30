using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {


    public GameObject enemyPrefab;
    List<GameObject> enemies = new List<GameObject>();
    bool waveStarted;
    bool canSpawnEnemy;
    public float spawnCountDown;
    public float waveStartCountDown;

    [SerializeField]
    float spawnTimer;
    [SerializeField]
    float waveTimer;

    public List<GameObject> nodeList = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        canSpawnEnemy = false;
        waveStarted = false;
        spawnTimer = spawnCountDown;
        waveTimer = waveStartCountDown;
	}
	
    


	// Update is called once per frame
	void Update ()
    {
	    if (waveStarted)
        {
            if (canSpawnEnemy)
            {

                spawnTimer = spawnCountDown;
                canSpawnEnemy = false;


                // spawn enemy here
                GameObject newItem = Instantiate(enemyPrefab);
                newItem.transform.parent = transform;


                EnemyScript enemyScript = newItem.GetComponent<EnemyScript>();


                enemyScript.NewList(nodeList);

                enemies.Add(newItem);
                
            }
            else
            {
                spawnTimer -= Time.deltaTime;


            }



            if (spawnTimer < 0)
            {
                canSpawnEnemy = true;
            }
        }
        else
        {
            waveTimer -= Time.deltaTime;
        }

        if (waveTimer < 0)
        {
            waveStarted = true;
        }

        
	}
}
