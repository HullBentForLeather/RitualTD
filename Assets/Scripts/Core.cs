using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Core : MonoBehaviour
{
    public static Core ActiveCore = null;

    public int MaxHealth = 10;

    int health;

    List<Pillar> pillars;

    public GameObject pillar;

    void OnEnable()
    {
        ActiveCore = this;
    }

    void OnDisable()
    {
        ActiveCore = null;
    }

    // Use this for initialization
    void Start ()
    {       
        health = MaxHealth;

        pillars = new List<Pillar>();

        Vector3 offset = new Vector3(0, 0, 5);

        float angleStep = 1 / (float)MaxHealth;     

        for (int i = 0; i < MaxHealth; ++i)
        {
            Quaternion rotate = Quaternion.Euler(new Vector3(0, angleStep * i * 360, 0));
            Vector3 pillarPos = rotate * offset;

            GameObject go = GameObject.Instantiate(pillar, pillarPos + transform.position, rotate) as GameObject;

            Pillar newPillar = go.GetComponent<Pillar>();

            pillars.Add(newPillar);

            newPillar.Initialise(this);
        }
	    
	}

    public void DoDamage(Pillar target)
    {
        if (pillars.Contains(target))
        {
            --health;
            pillars.Remove(target);
        }
    }

    public Pillar GetPillar()
    {
        if (health > 0)
        {
            return pillars[Random.Range(0, health)];
        }
        else
        {
            return null;
        }
    }
}
