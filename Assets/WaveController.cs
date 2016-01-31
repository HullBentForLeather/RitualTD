using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour
{
    public EnemySpawner spawn1;
    public EnemySpawner spawn2;
    public EnemySpawner spawn3;
    public EnemySpawner spawn4;
    public EnemySpawner spawn5;

    [SerializeField]
    bool wave1Done;
    [SerializeField]
    bool wave2Done;
    [SerializeField]
    bool wave3Done;
    [SerializeField]
    bool wave4Done;
    [SerializeField]
    bool wave5Done;
    [SerializeField]
    bool wave6Done;
    [SerializeField]
    bool wave7Done;
    [SerializeField]
    bool wave8Done;
    [SerializeField]
    bool wave9Done;
    [SerializeField]
    bool wave10Done;

    //public float 
    public OrbOfProgressBehav progress;

    [SerializeField]
    float wavetimer = 0;

    void OnEnable ()
    {
        EnemyScript.OnEnemyDied += EnemyDied;

    }
	
	// Update is called once per frame
	void Update ()
    {
        wavetimer += Time.deltaTime;

        

        if (!progress.IsWaveInProgress())
        {

            if (!wave1Done)
            {
                Wave1();
                wave1Done = true;
            }
            

            if (wavetimer >= 40 && !wave2Done)
            {
                Wave2();
                wave2Done = true;
            }

            if (wavetimer >= 75 && !wave3Done)
            {
                Wave3();
                wave3Done = true;
            }


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
        int enemies = 30;
        spawn1.StartWave(enemies, 0, 1, Color.red, 1);
        
        progress.newWave(enemies);
    }

    void Wave2()
    {
        int enemies = 30;
        spawn1.StartWave(10, 5, 1, Color.blue, 1);

        spawn2.StartWave(10, 10, 1, Color.blue, 1);

        spawn5.StartWave(10, 15, 1, Color.black, 1);

        progress.newWave(enemies);
    }

    void Wave3()
    {
        int enemies = 55;
        spawn1.StartWave(35, 10, 1, Color.red, 2);
        spawn2.StartWave(20, 0, 1, Color.blue, 2);


        progress.newWave(enemies);
    }

    void Wave4()
    {
        int enemies = 100;
        spawn1.StartWave(20, 0, 2, Color.red, 2);
        spawn2.StartWave(20, 0, 1, Color.red, 2);
        spawn3.StartWave(20, 0, 3, Color.red, 2);
        spawn4.StartWave(20, 0, 1, Color.red, 2);
        spawn5.StartWave(20, 0, 3, Color.red, 2);

        progress.newWave(enemies);
    }

    void Wave5()
    {
        int enemies = 120;
        spawn1.StartWave(40, 0, 2, Color.red, 2);
        spawn2.StartWave(40, 0, 1, Color.red, 2);
        spawn3.StartWave(40, 0, 3, Color.red, 2);


        progress.newWave(enemies);
    }

    void Wave6()
    {
        int enemies = 120;
        spawn1.StartWave(10, 0, 2, Color.green, 8);
        progress.newWave(enemies);
    }
    void Wave7()
    {
        int enemies = 30;
        spawn1.StartWave(10, 0, 2, Color.green, 8);
        spawn2.StartWave(10, 0, 2, Color.red,9);
        progress.newWave(enemies);
    }
}
