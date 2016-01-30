using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{

    public GameObject bullet;
    float shootDelay = 1f;
    bool canShoot;


    public Vector2 rightThumbStick;
    public Vector3 direction;
    float heading = 0;

    // Use this for initialization
    void Start()
    {
        canShoot = true;
    }

    void ResetShot()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rightThumbStick = new Vector2(Input.GetAxis("Right Horizontal"), Input.GetAxis("Right Vertical"));


        Transform mainCamera = Camera.main.transform;
        //direction = new Vector3(rightThumbStick.x, 0, rightThumbStick.y);
        direction = Vector3.right * rightThumbStick.x + Vector3.forward * rightThumbStick.y;
        if (rightThumbStick.sqrMagnitude < 0.1f)
        {

        }
        else
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

            if (canShoot)
            {
                Instantiate(bullet, transform.position, transform.rotation);

                canShoot = false;
                Invoke("ResetShot", shootDelay);
            }
        }
        //heading = Mathf.Atan2(rightThumbStick.x, rightThumbStick.y) * Mathf.Rad2Deg;
        //transform.rotation =  Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f );



    }
}
