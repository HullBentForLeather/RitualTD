﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class OrbOfProgressBehav : MonoBehaviour {
    //Declare stuff
    Image orb;
    Vector3 leftMostPos;
    Vector3 rightMostPos;
    List<float> waveEndValues;
    float x;
    float totalEnemies;
    float currentEnemies;
    int currentStage = -1;

    //GameObject line = new GameObject();

    bool waveInProgress = false;

    // Use this for initialization
    void Start () {

        leftMostPos = new Vector3(-494, -140, 0);
        rightMostPos = new Vector3(473, -140, 0);

        orb = GetComponent<Image>();
        orb.transform.localPosition = leftMostPos;

        //Initialise stuff
        waveEndValues = new List<float>();

        for (int i = 0; i < 10; i++)
        {
            waveEndValues.Add(1f / 9f * i);
        }

        //LINE STUFF
    //    line.transform.localPosition = leftMostPos;


        /*line.AddComponent<LineRenderer>();
        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.SetColors(Color.red, Color.red);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, leftMostPos);
        lr.SetPosition(1, orb.transform.localPosition);
        */

    }

    void UpdateUI()
    {
        if (currentStage >= 0)
        {
            if (currentStage < 9)
            {
                x = 1 - (currentEnemies / totalEnemies);
                float newx = Mathf.Lerp(waveEndValues[currentStage], waveEndValues[currentStage + 1], x);
                newx = Mathf.Lerp(leftMostPos.x, rightMostPos.x, newx);
                orb.transform.localPosition = new Vector3(newx, orb.transform.localPosition.y, orb.transform.localPosition.z);

            }
        }
        else
        {
            orb.transform.localPosition = leftMostPos;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("j"))
        {
            newWave(10);
        }


        if (Input.GetKeyDown("k"))
        {
            killEnemy();
        }
        if (Input.GetKeyDown("l"))
        {
            currentStage = -1;
            newWave(10);
            
        }

    }

    public void newWave(int enemies)
    {
        waveInProgress = true;
        currentStage++;
        currentEnemies = enemies;
        totalEnemies = enemies;
        UpdateUI();
    }

    public void killEnemy()
    {
        currentEnemies--;
        UpdateUI();
        if (currentEnemies == 0)
        {
            waveInProgress = false;
        }
    }

    public bool IsWaveInProgress()
    {
        return waveInProgress;
    }

}
