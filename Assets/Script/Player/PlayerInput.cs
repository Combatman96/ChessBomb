using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controller")] 
    public GridMovement movement;
    public SetBomb setBomb;
    
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
        //Handle Input for Movement
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            movement.MoveHorizontal(Input.GetAxisRaw("Horizontal"));
        }

        if ( Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            movement.MoveVertical(Input.GetAxisRaw("Vertical"));
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            setBomb.InitBomb();
        }
    }
}
