using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDetection : MonoBehaviour
{
    [Header("Movement Speed")] 
    public float seekSpeed = 4f;
    public float attackSpeed = 10f;

    [Header("Current State")]
    [SerializeField] private int state;
        
    private const int SEEK = 1;
    private const int ATTACK = 2;
    private const int DESTROYED = 3;

    [Header("Transform")] 
    //The player
    public Transform target;
    //The movePoint
    public Transform movePointEnemy;

    [Header("LayerMask")] public LayerMask whatStopMovement;

    private Vector3 attackDirection;
    
    private void Start()
    {
        state = SEEK;
        movePointEnemy.parent = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Manage State
        switch (state)
        {
            case SEEK:
                Seek();
                break;
            case ATTACK:
                Attack();
                break;
            case DESTROYED:
                Destroyed();
                break;
        }
        Debug.Log("State: " + state);
    }

    private Vector3 GETDirection()
    {
        var pos = target.transform.position;
        var direction = Vector3.zero;
        
        if (this.transform.position.x > pos.x)
        {
            direction.x = -1f;
        }
        if (this.transform.position.x < pos.x)
        {
            direction.x = 1f;
        }
        
        if (this.transform.position.y > pos.y)
        {
            direction.y = -1f;
        }
        if (this.transform.position.y < pos.y)
        {
            direction.y = 1f;
        }
        
        return direction;
    } 

    private void Seek()
    {
        //GO GO GO
        transform.position = Vector3.MoveTowards(transform.position, movePointEnemy.position, seekSpeed*Time.deltaTime);
        //Destination
        Vector3 direction = GETDirection();
        
        //Are the enemy there yet?
        if (Vector3.Distance(this.transform.position, movePointEnemy.position) == 0)
        {
            //Is there a block in the way?
            if (!Physics2D.OverlapCircle(movePointEnemy.position + direction, 0.2f, whatStopMovement))
            {
                movePointEnemy.position += direction;
            }
            
            //Check condition for changing to state: ATTACK 
            Vector3 localTargetPos = target.InverseTransformPoint(this.transform.position);
            if( (Mathf.Abs(localTargetPos.x) == Mathf.Abs(localTargetPos.y)) || localTargetPos.x == 0 || localTargetPos.y == 0)
            {
                attackDirection = GETDirection();
                state = ATTACK;
            }
        }
    }

    private void Attack()
    {
        //Rush now, ATTACK
        transform.position = Vector3.MoveTowards(transform.position, movePointEnemy.position, attackSpeed*Time.deltaTime);
        //Is there a block in the way?
        if (!Physics2D.OverlapCircle(movePointEnemy.position + attackDirection, 0.2f, whatStopMovement))
        {
            movePointEnemy.position += attackDirection;
        }
        if (Vector3.Distance(this.transform.position, movePointEnemy.position) == 0)
        {
            state = SEEK;
        }
    }

    private void Destroyed()
    {
        
    }
}
