using UnityEngine;
using System.Collections;

public class AreaExplosion : MonoBehaviour 
{
    float duration = 1f;

    Collider damageBox;
    ParticleSystem ps;

    float startTime;

	// Use this for initialization
	void Start () 
    {
        ps = GetComponentInChildren<ParticleSystem>();
        damageBox = GetComponentInChildren<Collider>();
        startTime = Time.time;
	}

    public void SetDuration(float time)
    {
        duration = time;
    }
	
	// Update is called once per frame
	void Update () 
    {
	    if (Time.time > startTime + duration)
        {
            damageBox.enabled = false;
            ps.Stop();
        }

        if(Time.time > startTime + duration + 2)
        {
            Destroy(this.gameObject);
        }
	}
}
