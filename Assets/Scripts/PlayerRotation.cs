using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {

    
    public Vector2 playerFacingPosition;
    public Vector3 direction;
    float heading = 0;
    Vector3 newRotation;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = Input.GetAxis("Fire2");
        float speedRight = Input.GetAxis("Fire1");

        if (speed > 0.1f)
        {
          Quaternion newRotation = Quaternion.Euler(0, - speed, 0);
            
            transform.rotation = transform.rotation * newRotation;

        }
        if (speedRight > 0.1f)
        {
            Quaternion newRotation = Quaternion.Euler(0, speedRight, 0);

            transform.rotation = transform.rotation * newRotation;
        }

      //playerFacingPosition = new Vector2(Input.GetAxis("Fire1"), Input.GetAxis("Fire1"));
        
       

        //Transform mainCamera = Camera.main.transform;
        //direction = new Vector3(playerFacingPosition.x, 0, playerFacingPosition.y);

        //if (playerFacingPosition.sqrMagnitude < 0.1f)
        //{

        //}
        //else
        //{
        //    // transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

      
        //}


        //heading = Mathf.Atan2(rightThumbStick.x, rightThumbStick.y) * Mathf.Rad2Deg;
        //transform.rotation =  Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f );



    }
}
