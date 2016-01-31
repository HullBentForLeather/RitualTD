using UnityEngine;
using System.Collections;

public class MissileAttack : MonoBehaviour 
{
    public float attackDelay = 0.5f;

    public Transform missileOrigin;

    public GameObject missile;

    public AudioSource attackSound;

    bool attackRequested = false;

    bool attackInProgress = false;

    public void StartAttacking()
    {
        attackRequested = true;
    }

    public void StopAttacking()
    {
        attackRequested = false;
    }

    void Update()
    {
        if (attackRequested && !attackInProgress)
        {
            StartCoroutine(DoAttack());
        }
    }

    IEnumerator DoAttack()
    {
        attackInProgress = true;

        GameObject.Instantiate(missile, missileOrigin.position, missileOrigin.rotation);
        attackSound.Play();

        yield return new WaitForSeconds(attackDelay);
        attackInProgress = false;
    }
}
