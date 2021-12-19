using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public Transform movePoint;
    public float moveSpeed = 5f;
    
    public Transform playerTransform;
    
    [Header("LayerMask")] public LayerMask whatStopMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move player toward movePoint
        playerTransform.position =
           Vector3.MoveTowards(playerTransform.position, movePoint.position, moveSpeed * Time.deltaTime);
      
        //rb.MovePosition((Vector2)playerTransform.position + ((Vector2)movePoint.position * Time.deltaTime ));
        //Debug.Log(movePoint.position);
    }

    public void MoveHorizontal(float x)
    {
        //Check whether there an obstacle ahead
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(x, 0, 0), 0.2f, whatStopMovement))
        {
            //Set new position to movePoint
            movePoint.position += new Vector3(x, 0f, 0f);
        }
    }

    public void MoveVertical(float y)
    {
        //Check whether there an obstacle ahead
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, y,0), 0.2f, whatStopMovement))
        {
            //Set new position to movePoint
            movePoint.position += new Vector3(0f, y, 0f);
        }
    }
}
