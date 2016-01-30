using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour
{
    bool built = false;

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
	    if (!built && playerInBounds && Input.GetButtonDown("Fire1"))
        {
            GameObject.Instantiate(tower, transform.position, transform.rotation);
            built = true;
        }
	}
}
