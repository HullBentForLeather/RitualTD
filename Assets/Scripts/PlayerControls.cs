using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    SwordAttack swordAttack;
    AreaAttack areaAttack;
    MissileAttack missileAttack;

    PlayerRotation playerRotation;

    public float movespeed = 10.0f;

    Vector2 turnDirection = Vector2.zero;

    // Use this for initialization
    void Start ()
    {
        swordAttack = GetComponent<SwordAttack>();
        areaAttack = GetComponent<AreaAttack>();
        missileAttack = GetComponent<MissileAttack>();

        playerRotation = GetComponent<PlayerRotation>();
	}

    void DoMovement()
    {
        Vector2 leftThumbStick = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Prevent issue where moving diagonally is faster
        if (leftThumbStick.magnitude > 1)
        {
            leftThumbStick.Normalize();
        }

        leftThumbStick = leftThumbStick * Time.deltaTime * movespeed;

        transform.Translate(new Vector3(leftThumbStick.x, 0, leftThumbStick.y));
    }

    void DoTurning()
    {
        Vector2 rightThumbStick = new Vector2(Input.GetAxis("Right Horizontal"), Input.GetAxis("Right Vertical"));

        if (rightThumbStick.magnitude > 0.2f)
        {
            turnDirection = rightThumbStick.normalized;

            playerRotation.RotateDirection(turnDirection);
        }
        else
        {
            turnDirection = Vector2.zero;
        }
    }

    void DoAttacks()
    {

        if (Input.GetButtonDown("Forward Attack"))
        {
            swordAttack.StartAttacking();
        }
        else if (Input.GetButtonUp("Forward Attack"))
        {
            swordAttack.StopAttacking();
        }

        if (Input.GetButtonDown("Area Attack"))
        {
            areaAttack.StartAttacking();
        }
        else if (Input.GetButtonUp("Area Attack"))
        {
            areaAttack.StopAttacking();
        }

        if (turnDirection != Vector2.zero)
        {
            missileAttack.StartAttacking();
        }
        else
        {
            missileAttack.StopAttacking();
        }
    }


    void Update()
    {
        if (Input.GetButton("Escape"))
        {
            Application.Quit();
        }
        DoMovement();

        DoTurning();

        DoAttacks();        
    }
}
