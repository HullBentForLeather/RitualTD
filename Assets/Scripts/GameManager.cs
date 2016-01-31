using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject gameOverScreen;
    // Use this for initialization
    void Start()
    {

    }
    static int shrineHP = 10;
    // Update is called once per frame
    void Update()
    {
        if (shrineHP <= 0 )
        {


            gameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;

        }
    }

    public static void PillarFallDown()
    {
        Debug.Log("YOU DYING SUCKAH!. YOU GOT " + shrineHP + " LEFT" );
        shrineHP--;
    }



}
