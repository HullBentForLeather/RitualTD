using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour
{
   // public bool built = false;

    bool playerInBounds = false;

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
	    if (playerInBounds && Input.GetButtonDown("Build Tower"))
        {
            clang = GetComponent<AudioSource>();
            clang.Play();
            gameObject.SetActive(true);
            GameObject.Instantiate(tower, transform.position, transform.rotation);
            
              
        }
	}
}
