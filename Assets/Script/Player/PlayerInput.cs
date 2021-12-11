﻿using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controller")] 
    public GridMovement movement;
    
    [Header("Transform")]
    public Transform movePoint;

    public GameObject obstacle;
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.TransformPoint(0f, 0f ,0f), movePoint.position) <= 0.1f)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        //Handle Input for Movement
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            movement.MoveHorizontal(Input.GetAxisRaw("Horizontal"));
        }

        if ( Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            movement.MoveVertical(Input.GetAxisRaw("Vertical"));
        }
        
        //Set the Bomb (Testing at the moment)
        if (Input.GetButtonUp("Jump"))
        {
            Instantiate(obstacle, transform.TransformPoint(0f, 0f, -3f), Quaternion.Euler(0,0,0));
            AstarPath.active.Scan(); //Rescan the navigation grid
        }
    }
}
