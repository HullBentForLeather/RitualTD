using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour
{
    public float attackDuration = 1f;
    public float attackDelay = 0.5f;

    public GameObject explosion;

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

        GameObject expl = GameObject.Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        expl.GetComponent<AreaExplosion>().SetDuration(attackDuration);
        attackSound.Play();      

        yield return new WaitForSeconds(attackDuration + attackDelay);    
        attackInProgress = false;
    }
}
