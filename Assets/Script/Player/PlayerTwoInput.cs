using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoInput : MonoBehaviour
{
    [Header("Controller")] 
    public GridMovement movement;
    public PlayerTwoSetBomb setBomb;
    
    [Header("Transform")]
    public Transform movePoint;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.TransformPoint(0f, 0f ,0f), movePoint.position) == 0f)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        //Handle Input for Movement J I K L
        if (Input.GetKey(KeyCode.J))
        {
            movement.MoveHorizontal(-1);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            movement.MoveHorizontal(1);
        }

        if (Input.GetKey(KeyCode.I))
        {
            movement.MoveVertical(1);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            movement.MoveVertical(-1);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            setBomb.InitBomb();
        }
    }
}
