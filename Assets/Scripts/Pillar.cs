using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour, IDamageable
{
    public bool Alive;
    AudioSource crash;
    Core myCore;

    void Start()
    {
        Alive = true;
        crash = GetComponent<AudioSource>();
    }
    
    public void DoDamage(int amount)
    {
        Destroy();
    }

    void Destroy()
    {
        if (Alive)
        {           
            Alive = false;
            myCore.DoDamage(this);

            crash.Play();

            GameManager.PillarFallDown();

            StartCoroutine(FallDown());


        }
        
    }

    public void Initialise(Core core)
    {
        myCore = core;
    }

    IEnumerator FallDown()
    {
        
        Quaternion fall = transform.localRotation * Quaternion.Euler(90, 0, 0);
        Quaternion start = transform.localRotation;

        float delta = Time.deltaTime;

        while (delta < 1)
        {
            transform.localRotation = Quaternion.Lerp(start, fall, delta);
            yield return null;

            delta += Time.deltaTime;
        }

        transform.localRotation = fall;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public bool IsAlive()
    {
        if (Alive)
        {
            return true;
        }

        return false;
    }

}
