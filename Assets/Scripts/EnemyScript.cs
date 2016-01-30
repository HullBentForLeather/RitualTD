using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{

    [SerializeField]
    int HP;
    public int startingHP;

    public List<GameObject> nodeList;

    float speed = 0.01f;

    [SerializeField]
    int targetIndex = 0;


    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 directionOfTravel;

    public void NewList(List<GameObject> inNodeList)
    {
        nodeList = inNodeList;
    }



    // Use this for initialization
    void Start ()
    {
        HP = startingHP;
        targetIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
	}

    void FixedUpdate()
    {
        
        directionOfTravel = nodeList[targetIndex].transform.position - transform.position;


        //Debug.ClearDeveloperConsole();
        //Debug.Log("The position for the target is X:" + nodeList[0].transform.position.x + " Y:" + nodeList[0].transform.position.y + " Z:" + nodeList[0].transform.position.z);
        //Debug.Log("The position of the enemy is X:" + transform.position.x + " Y:" + transform.transform.position.y + " Z:" + transform.position.z);

        


        transform.Translate((directionOfTravel.x * speed), (0), (directionOfTravel.z * speed), Space.World);
        
        //Debug.Log(Vector3.Distance(transform.position, nodeList[targetIndex].transform.position));
        if (Vector3.Distance(transform.position, nodeList[targetIndex].transform.position) < 4f)
        {
            //Debug.Log(Vector3.Distance(transform.position, nodeList[targetIndex].transform.position));
            if (targetIndex < nodeList.Count - 1)
            {
                targetIndex++;
            }

        }
        

    }

    void OnCollisionEnter(Collision coll)
    {


        if (coll.gameObject.tag == "HitBox")
        {
            HP--;
        }

        

    }

}
