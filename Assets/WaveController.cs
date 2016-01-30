using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour
{
    public EnemySpawner spawn1;
    public EnemySpawner spawn2;
    public EnemySpawner spawn3;
    public EnemySpawner spawn4;
    public EnemySpawner spawn5;

    public OrbOfProgressBehav progress;


    void OnEnable ()
    {
        EnemyScript.OnEnemyDied += EnemyDied;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!progress.IsWaveInProgress())
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Wave1();
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Wave2();
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                Wave3();
            }

            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Wave4();
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Wave5();
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Wave6();
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Wave7();
            }
            //if (Input.GetKeyDown(KeyCode.Keypad5))
            //{
            //  //  Wave8();
            //}
            //if (Input.GetKeyDown(KeyCode.Keypad5))
            //{
            // //   Wave9();
            //}
        }
	}

    void EnemyDied()
    {
        progress.killEnemy();
    }

    void Wave1() 
    {
        int enemies = 5;
        spawn1.StartWave(enemies, 5, 1, Color.red);
        progress.newWave(enemies);
    }

    void Wave2()
    {
        int enemies = 10;
        spawn1.StartWave(5, 5, 1, Color.blue);

        spawn2.StartWave(5, 10, 1.5f, Color.blue);

        progress.newWave(enemies);
    }

    void Wave3()
    {
        int enemies = 20;
        spawn1.StartWave(10, 0, 2, Color.red);
        spawn2.StartWave(10, 0, 3, Color.blue);


        progress.newWave(enemies);
    }

    void Wave4()
    {
        int enemies = 30;
        spawn1.StartWave(10, 0, 2, Color.red);
        spawn2.StartWave(10, 0, 1, Color.red);
        spawn3.StartWave(10, 0, 3, Color.red);
      
        progress.newWave(enemies);
    }

    void Wave5()
    {
        int enemies = 10;
        spawn3.StartWave(10, 0, 2, Color.green);
        progress.newWave(enemies);
    }

    void Wave6()
    {
        int enemies = 20;
        spawn1.StartWave(10, 0, 2, Color.green);
        progress.newWave(enemies);
    }
    void Wave7()
    {
        int enemies = 30;
        spawn1.StartWave(10, 0, 2, Color.green);
        spawn2.StartWave(10, 0, 2, Color.red);
        progress.newWave(enemies);
    }
}
