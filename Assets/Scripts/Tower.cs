using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    IDamageable currentTarget = null;

    float time = Time.time;

    float checkRate = 0.1f;
    float checkTimer = 0;

    public float Range = 5;
    public int Damage = 1;

    float lastShot = 0;
    float fireRate = 0.6f;

    public Transform shotOrigin;

    public GameObject bullet;

   
    public void Start()
    {
        // Wait a second before we can fire
        lastShot = Time.time + 1 - fireRate;
    }

    void OnDrawGizmos()
    {
        if (currentTarget != null)
        {
            if (lastShot + 0.2f > Time.time)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.white;
            }

            Gizmos.DrawLine(shotOrigin.position, currentTarget.GetPosition());            
        }
        Gizmos.DrawWireSphere(transform.position, Range);

        
    }

    public void Update ()
    {

        checkTimer += Time.deltaTime;

        if (currentTarget == null && checkTimer >= checkRate)
        {
            checkTimer -= checkRate;
            DoTargetCheck();  
                      
        }

        if (currentTarget != null)
        {
            if (!currentTarget.IsAlive() || Vector3.Distance(currentTarget.GetPosition(), transform.position) > Range)
            {
                currentTarget = null;
            }
        }

        if (currentTarget != null)
        {
            TryShot();
        }

        
	
	}

    void DoTargetCheck()
    {
        float closest = float.MaxValue;
        foreach(IDamageable id in EnemyScript.ActiveEnemies)
        {
            float currentDistance = Vector3.Distance(id.GetPosition(), transform.position);

            if (currentDistance < closest)
            {
                closest = currentDistance;
                currentTarget = id;
            }
        }
    }

    void TryShot()
    {
        if (Time.time > lastShot + fireRate)
        {
            lastShot = Time.time;

            GameObject bull = GameObject.Instantiate(bullet, shotOrigin.position, Quaternion.identity) as GameObject;
            Shot result = bull.GetComponent<Shot>();
            result.SetTarget(currentTarget);
            result.SetDamage(Damage);
        }
    }
}
