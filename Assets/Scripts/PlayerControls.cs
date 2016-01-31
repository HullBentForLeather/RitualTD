using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{


    [SerializeField]
    Vector2 leftThumbStick;

    public GameObject forwardHitBox;
    public GameObject areaHitBox;

    [SerializeField]
    float attackDuration;
    [SerializeField]
    float areaAttackCoolDown;
    [SerializeField]
    float attackCoolDown;

    [SerializeField]
    float forwardAttackTimer;
    [SerializeField]
    float areaAttackTimer;

    bool forwardAttacking;
    bool areaAttacking;

    // Use this for initialization
    void Start ()
    {
        leftThumbStick = Vector2.zero;
        forwardAttackTimer = attackCoolDown;
        areaAttackTimer = attackCoolDown;
        forwardAttacking = false;
        areaAttacking = false;
	}

    void ForwardAttackCheck()
    {
        if (forwardAttacking)
        {
            forwardAttackTimer -= Time.deltaTime;

            if (forwardAttackTimer < attackCoolDown - attackDuration)
            {
                forwardHitBox.SetActive(false);
            }
            else
            {
                forwardHitBox.SetActive(true);
            }

            if (forwardAttackTimer <= 0)
            {
                forwardAttackTimer = attackCoolDown;
                forwardAttacking = false;
            }
        }
    }



    void AreaAttackCheck()
    {
        if (areaAttacking)
        {
            areaAttackTimer -= Time.deltaTime;

            if (areaAttackTimer < areaAttackCoolDown - attackDuration)
            {
                areaHitBox.SetActive(false);
            }
            else
            {
                areaHitBox.SetActive(true);
            }

            if (areaAttackTimer <= 0)
            {
                areaAttackTimer = areaAttackCoolDown;
                areaAttacking = false;
            }
        }


       
    }

	void ActionCheck()
    {


        ForwardAttackCheck();
        AreaAttackCheck();

        


    }


    void Update()
    {
        if (Input.GetButton("Forward Attack"))
        {
            forwardAttacking = true;
        }

        if (Input.GetButton("Area Attack"))
        {
            areaAttacking = true;
        }

        ActionCheck();
    }
	// Update is called once per frame
	void FixedUpdate()
    {
        leftThumbStick = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        transform.Translate(new Vector3(leftThumbStick.x,0 , leftThumbStick.y));

        
        


        
	}
}
