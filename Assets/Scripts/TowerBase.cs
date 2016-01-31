using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour
{
   // public bool built = false;

    bool playerInBounds = false;

    bool towerActive = false;

    AudioSource clang;

    public GameObject tower;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInBounds = true;
        }

        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInBounds = false;
        }
    }

	// Update is called once per frame
	void Update ()
    {
	    if (!towerActive && playerInBounds && Input.GetButtonDown("Build Tower"))
        {
            clang = GetComponent<AudioSource>();
            clang.Play();


            towerActive = true;
            StartCoroutine(StartTower());
        }
	}

    IEnumerator StartTower()
    {
        tower.SetActive(true);

        Vector3 startPos = tower.transform.localPosition;
        Vector3 targetPos = startPos + new Vector3(0, 2, 0);

        float timer = 0;

        while (timer < 1)
        {
            timer += Time.deltaTime;
            yield return null;
            tower.transform.localPosition = Vector3.Lerp(startPos, targetPos, timer);
        }

        tower.transform.localPosition = targetPos;

        yield return new WaitForSeconds(19);

        timer = 0;

        while (timer < 1)
        {
            timer += Time.deltaTime;
            yield return null;
            tower.transform.localPosition = Vector3.Lerp(targetPos, startPos, timer);
        }

        tower.transform.localPosition = startPos;

        tower.SetActive(false);
        towerActive = false;
    }
}
