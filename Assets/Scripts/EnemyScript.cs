﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour, IDamageable
{
    public static List<EnemyScript> ActiveEnemies = new List<EnemyScript>();

    public delegate void EnemyDied();
    public static event EnemyDied OnEnemyDied;

    [SerializeField]
    int HP;
    public int startingHP;

    public PathNode currentNode;

    public float speed = 1f;

    [SerializeField]
    int targetIndex = 0;


    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 directionOfTravel;

    IDamageable target = null;

    public float AttackDelay = 1f;
    public int AttackDamage = 1;

    public void SetStartNode(PathNode node)
    {
        currentNode = node;
    }

    public void setHP(int HP)
    {
        this.HP = HP;
        this.startingHP = HP;
    }

    // Use this for initialization
    void Start ()
    {      
        HP = startingHP;
        targetIndex = 0;
        ActiveEnemies.Add(this);
	}

    public void DoDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            ActiveEnemies.Remove(this);
            gameObject.SetActive(false);

            if (OnEnemyDied != null)
            {
                OnEnemyDied();
            }
        }
    }

    public bool IsAlive()
    {
        if (HP <= 0)
            {
            return false;        
            }

        return true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    float attackCounter = 0;

    void FixedUpdate()
    {
        if (target != null && !target.IsAlive())
        {
            target = null;
        }

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.GetPosition(), speed * Time.deltaTime);


            Vector3 dir = target.GetPosition() - transform.position;
            dir.y = 0;

            if (dir.magnitude > 0)
            {
                dir.Normalize();

                Quaternion targetrot = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetrot, Time.deltaTime * 10);
            }

            if (Vector3.Distance(transform.position, target.GetPosition()) < 0.5f)
            {
                attackCounter += Time.deltaTime;

                if (attackCounter > AttackDelay)
                {
                    attackCounter = 0;
                    target.DoDamage(AttackDamage);                    
                }
            }
            else
            {
                attackCounter = 0;
            }
        }
        else
        {
            if (currentNode != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);

                Vector3 dir = currentNode.transform.position - transform.position;
                dir.y = 0;

                if (dir.magnitude > 0)
                {
                    dir.Normalize();

                    Quaternion targetrot = Quaternion.LookRotation(dir, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetrot, Time.deltaTime *10);
                }

                if (Vector3.Distance(transform.position, currentNode.transform.position) < 0.1f)
                {
                    currentNode = currentNode.nextNode;
                }
            }
            else
            {
                target = Core.ActiveCore.GetPillar();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "HitBox")
        {
            DoDamage(1);
        }

        

    }

}
