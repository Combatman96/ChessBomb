using UnityEngine;

public class RookState : MonoBehaviour
{
    [SerializeField] static int state;

    private const int SEEK = 1;
    private const int ATTACK = 2;
    private const int DESTROYED = 3;
    
    //Component Script for states change
    private EnemyMovement _enemyMovement;
    private RookAttack _rookAttack;

    [Header("Transform")] 
    public Transform target;
    public Transform rookMovePoint;
    public Transform rookTransform;
    
    // Start is called before the first frame update
    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _rookAttack = GetComponent<RookAttack>();
        state = 1;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        switch (state)
        {
            case SEEK:
                SeekState();
                break;
            
            case ATTACK:
                break;
            
            case DESTROYED:
                break;
        }
    }

    private void SeekState()
    {
        _enemyMovement.enabled = true;
        _rookAttack.enabled = false;


        var position = rookTransform.position;
        
        Vector2 rayLeft = (Vector2) position + new Vector2(-0.5f, 0f);
        RaycastHit2D hitPointLeft = Physics2D.Raycast(rayLeft, Vector2.left, 9f);
        Debug.DrawRay(rayLeft, Vector2.left, Color.magenta);
        
        Vector2 rayUp = (Vector2) position + new Vector2(0, 0.5f);
        RaycastHit2D hitPointUp = Physics2D.Raycast(rayUp, Vector2.up, 9f);
        Debug.DrawRay(rayUp, Vector2.up, Color.magenta);
        
        Vector2 rayRight = (Vector2) position + new Vector2(0.5f, 0f);
        RaycastHit2D hitPointRight = Physics2D.Raycast(rayRight, Vector2.right, 9f);
        Debug.DrawRay(rayRight, Vector2.right, Color.magenta);
        
        Vector2 rayDown = (Vector2) position + new Vector2(0f, -0.5f);
        RaycastHit2D hitPointDown = Physics2D.Raycast(rayDown, Vector2.down, 9f);
        Debug.DrawRay(rayDown, Vector2.down, Color.magenta);
        
        if (Vector2.Distance((Vector2) rookTransform.position, (Vector2) rookMovePoint.position) == 0f)
        {

            if (hitPointLeft.collider.CompareTag("Player") || hitPointUp.collider.CompareTag("Player")
                || hitPointRight.collider.CompareTag("Player") || hitPointDown.collider.CompareTag("Player"))
            {
                Debug.Log("Detected");
                state = ATTACK;
            }
        }
    }
}
