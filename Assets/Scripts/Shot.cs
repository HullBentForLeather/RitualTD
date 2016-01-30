using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    IDamageable shotTarget = null;
    Vector3 startPoint;
    Vector3 pointTarget;

    int ShotDamage = 1;

    public void SetTarget(IDamageable target)
    {
        shotTarget = target;
    }

    public void SetDamage(int amount)
    {
        ShotDamage = amount;
    }

    void Start()
    {
        startPoint = transform.position;
    }

    float timer = 0;
	
    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if (shotTarget != null && !shotTarget.IsAlive())
        {
            pointTarget = shotTarget.GetPosition();
            shotTarget = null;
        }

        if (shotTarget != null)
        {
            transform.position = Vector3.Lerp(startPoint, shotTarget.GetPosition(), timer);
        }
        else
        {
            transform.position = Vector3.Lerp(startPoint, pointTarget, timer);
        }

        if (timer > 1f)
        {
            if (shotTarget != null)
            {
                shotTarget.DoDamage(ShotDamage);
            }
            Destroy(this.gameObject);
        }
	}
}
