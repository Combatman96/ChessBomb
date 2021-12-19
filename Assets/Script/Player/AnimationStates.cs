using UnityEngine;

public class AnimationStates : MonoBehaviour
{
    [Header("Transform")] 
    public Transform movePoint;
    
    [Header("Components")] 
    public Animator animator;
    public SpriteRenderer playerSprite;
    public new Collider2D collider;

    [Header("Views")] 
    public PlayerInput playerInput;
    public PlayerTwoInput playerTwoInput;
    
    // Update is called once per frame
    void Update()
    {
        if (playerInput != null)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                playerSprite.flipX = true;
            }

            if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                playerSprite.flipX = false;
            }
        }
        else if (playerTwoInput != null)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                playerSprite.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                playerSprite.flipX = false;
            }
        }
        
        if (Vector3.Distance(transform.TransformPoint(0f, 0f, 0f), movePoint.position) <= 0.1f)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }

    public void Defeated()
    {
        collider.enabled = false;
        animator.SetBool("IsDefeated", true);
        if (playerInput != null)
        {
            playerInput.enabled = false;
        }
        if(playerTwoInput != null)
        {
            playerTwoInput.enabled = false;
        }
    }
}
