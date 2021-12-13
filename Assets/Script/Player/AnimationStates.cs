using UnityEngine;

public class AnimationStates : MonoBehaviour
{
    [Header("Transform")] public Transform movePoint;
    [Header("Components")] public Animator animator;
    [Header("Components")] public SpriteRenderer playerSprite;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            playerSprite.flipX = true;
        }
        if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            playerSprite.flipX = false;
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
}
