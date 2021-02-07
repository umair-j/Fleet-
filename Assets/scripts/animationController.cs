using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    public Rigidbody rb;
    
    private Animator anim;

    // Start is called before the first frame update
    private void Awake()
    {
        
        anim = GetComponent<Animator>();
        anim.ResetTrigger("won");
        anim.ResetTrigger("isrunning");
        anim.ResetTrigger("isjumping");
        //anim.SetBool("Won", false);
        //anim.SetBool("isRunning", false);
        
    }
    void Start()
    {
        transform.Rotate(0, -5, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isActive)
        {
            


            if (Input.GetKeyDown(KeyCode.Space) && playerMovement.isGrounded && increaseSize.canJump)
            {
                transform.Rotate(0, -18, 0);
                anim.SetTrigger("isjumping");
                //anim.SetBool("isJumping", true);
            }
            //anim.SetBool("isJumping", false);

            if (Input.anyKeyDown)
                {
                anim.SetTrigger("isrunning");
                //anim.SetBool("isRunning", true);
                //anim.Play("Running");    
            }
        }

    }

    private Vector2 fp; // first finger position
    private Vector2 lp; // last finger position

    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                
                if ((fp.y - lp.y) < -80) // up swipe
                {
                    if (playerMovement.isGrounded && increaseSize.canJump)
                    {

                        rb.AddForce(new Vector3(0, playerMovement.jumpForce, 0), ForceMode.Impulse);
                        playerMovement.isGrounded = false;
                    }
                }

            }
        }
    }

}
