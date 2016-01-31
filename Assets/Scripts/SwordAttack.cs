using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour 
{
    public float attackDuration = 0.2f;
    public float attackDelay = 0.5f;

    public GameObject damageBox;

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

    void Start()
    {
        damageBox.SetActive(false);
    }

	void Update () 
    {
	    if (attackRequested && !attackInProgress)
        {
            StartCoroutine(DoAttack());
        }
	}

    IEnumerator DoAttack()
    {
        attackInProgress = true;

        damageBox.SetActive(true);
        attackSound.Play();

        yield return new WaitForSeconds(attackDuration);
        damageBox.SetActive(false);

        yield return new WaitForSeconds(attackDelay);
        attackInProgress = false;
    }
}
