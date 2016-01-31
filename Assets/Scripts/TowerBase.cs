using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour
{
   // public bool built = false;

    bool playerInBounds = false;


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
	    if (playerInBounds && Input.GetButtonDown("Build Tower"))
        {
            gameObject.SetActive(true);
            GameObject.Instantiate(tower, transform.position, transform.rotation);  
        }
	}
}
