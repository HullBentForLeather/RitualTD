using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    bool gameOver = false;
    public GameObject gameOverScreen;
    static int shrineHP = 10;


    // Use this for initialization
    void Start()
    {
        shrineHP = 10;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (shrineHP <= 0 )
        {
            if (!gameOver)
            {
                gameOver = true;
                StartCoroutine(loadmainmenu());
            }


            
        }
    }

    IEnumerator loadmainmenu ()
    {
        gameOverScreen.SetActive(true);
        EnemyScript.ActiveEnemies.Clear();
        Core.ActiveCore = null;
        //Time.timeScale = 0.0f;
        yield return new WaitForSeconds(5);
        Application.LoadLevel(0);
    }

    public static void PillarFallDown()
    {
        
        shrineHP--;
    }



}
