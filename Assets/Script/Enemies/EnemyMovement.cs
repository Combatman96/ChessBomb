using Pathfinding;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("Transform")] 
    public Transform target;
    public Transform enemyMovePoint;
    public Transform enemy;
    
    [Header("Movements")] public float moveSpeed = 4f;
    //public float nextWayPointDistance = 1f;

   // [Header("LayerMask")] public LayerMask whatStopMovements;
    
    private Path path;
    private int currentWaypoint = 0;
    //private bool _reachedEndOfPath = false;

    private Seeker seeker;
    
    //public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMovePoint.parent = null;
        seeker = GetComponent<Seeker>();
        //InvokeRepeating(nameof(UpdatePath), 0f, 1f);
        UpdatePath();
    }
    
    
    public void UpdatePath()
    {
        //Generating path
        if (seeker.IsDone())
        {
            seeker.StartPath(enemy.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p; // assign current path if there is no error
            currentWaypoint = 1;
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Is there a path?
        if (path == null)
        {
            return;
        }
        //Are we at the end of path?
        if (currentWaypoint >= path.vectorPath.Count)
        {
            //_reachedEndOfPath = true;
            return;
        }
        else
        {
            //_reachedEndOfPath = false;
        }
        
        //OK Move
        Move();
        
        
    }

    private void Move()
    {
        var direction =  path.vectorPath[currentWaypoint];
        enemyMovePoint.position = direction;
        enemy.position = Vector3.MoveTowards(enemy.position, enemyMovePoint.position, moveSpeed * Time.deltaTime);
        //rb.MovePosition((Vector2)enemyMovePoint.position * Time.deltaTime);
        if ((Vector2)direction == (Vector2)enemy.position)
        {
            enemyMovePoint.position =  direction;
            AstarPath.active.Scan();
            
            currentWaypoint++;
            UpdatePath();
            //Debug.Log("Arrived");
        }
    }
}
