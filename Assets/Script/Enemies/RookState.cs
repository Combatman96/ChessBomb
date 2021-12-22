using System;
using UnityEngine;

public class RookState : MonoBehaviour
{
    [SerializeField]
    public static int state;

    private const int SEEK = 1;
    private const int ATTACK = 2;
    private const int DESTROYED = 3;

    [Header("Game Object")] public GameObject rook;
    [Header("Model")] public LevelData levelData;
    [Header("Components")] public Animator animator;
    
    //Component Script for states change
    private EnemyMovement _enemyMovement;
    private RookAttack _rookAttack;
  
    
    [Header("Transform")] 
    public Transform target;
    public Transform rookMovePoint;
    public Transform rookTransform;

    private Vector2 attackDirection;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

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
                AttackState();
                break;
            
            case DESTROYED:
                DestroyedState();
                break;
        }
    }

    private void SeekState()
    {
        _enemyMovement.enabled = true;
        _rookAttack.enabled = false;
  
        //Play the animation
        animator.SetBool("IsAttacking", false);
        
        //Check for the player in range (4 directions), if condition met then change stage to ATTACK
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
            if (hitPointLeft.collider.CompareTag("Player"))
            {
                Debug.Log("Detected");
                attackDirection = Vector2.left;
                state = ATTACK;
            }
            if (hitPointRight.collider.CompareTag("Player"))
            {
                Debug.Log("Detected");
                attackDirection = Vector2.right;
                state = ATTACK;
            }
            if (hitPointUp.collider.CompareTag("Player"))
            {
                Debug.Log("Detected");
                attackDirection = Vector2.up;
                state = ATTACK;
            }
            if (hitPointDown.collider.CompareTag("Player"))
            {
                Debug.Log("Detected");
                attackDirection = Vector2.down;
                state = ATTACK;
            }
        }
    }
    
    private void AttackState()
    {
        _enemyMovement.enabled = false;
        _rookAttack.enabled = true;
        
        //Play the animation
        animator.SetBool("IsAttacking", true);

        RookAttack.attackDirection = this.attackDirection;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explode"))
        {
            state = DESTROYED;
        }
    }
    
    private void DestroyedState()
    {
        _enemyMovement.enabled = false;
        _rookAttack.enabled = false;
        
        levelData.DestroyedAnEnemy();
        Destroy(rook);
    }

}
