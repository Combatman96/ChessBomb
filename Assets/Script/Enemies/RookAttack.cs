using UnityEngine;

public class RookAttack : MonoBehaviour
{
    public static Vector2 attackDirection;

    [Header("Attack Speed")] public float attackSpeed = 7f;

    [Header("Transform")] 
    public Transform rookMovePoint;
    public Transform rookTransform;

    [Header("Layer Mask")] public LayerMask whatStopAttack;
    
    // Update is called once per frame
    private void Update()
    {
        //Move to Attack Now
        rookTransform.position = Vector3.MoveTowards(rookTransform.position, rookMovePoint.position, attackSpeed* Time.deltaTime);
        if(!Physics2D.OverlapCircle((Vector2)rookMovePoint.position + attackDirection, 0.2f,  whatStopAttack))
        {
            rookMovePoint.position += (Vector3)attackDirection;
        }
        //Change back to Seek if:
        if (Vector2.Distance(rookTransform.position, rookMovePoint.position) == 0)
        {
            RookState.state = 1;
        }
    }
}
