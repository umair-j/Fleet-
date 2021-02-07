using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Text levelText;
    public static float size;
    public GameObject restartWindow;
    public static bool isActive;
    public static float jumpForce;
    private Vector3 jump = new Vector3(0f, jumpForce, 0f);
    public static bool isGrounded;

    public static float speed;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        levelText.text = "LEVEL" + increaseSize.levelNumber.ToString();
        size = 1f;
        restartWindow.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        jumpForce = 30f;
        speed = 15;
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isActive && cameramovement.stop==false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && increaseSize.canJump)
            {

                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isGrounded = false;
            }
            if(Input.GetAxis("Horizontal") == 1)
            {
                if (rb.transform.position.x < 6)
                {
                    rb.transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0);
                }
            }
            if (Input.GetAxis("Horizontal") == -1) { 
                if (rb.transform.position.x > -6)
            {
                rb.transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0);
            }
            }
            //transform.Rotate(0, Input.GetAxis("Horizontal") * 100 * Time.deltaTime, 0);
            //transform.Rotate(0, -Input.GetAxis("Horizontal") * 100 * Time.deltaTime, 0);
            rb.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            
            if(rb.transform.position.y < -1)
            {
                
                restartWindow.SetActive(true);
                //Debug.Log("dead");
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(increaseSize.levelNumber);
                }
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
                if ((fp.x - lp.x) > -20) // left swipe
                {
                    if (rb.transform.position.x > -5.5f)
                    {


                        rb.transform.position += new Vector3(-1 * (fp.x - lp.x)/20 * Time.deltaTime, 0, 0);
                    }

                }
                else if ((fp.x - lp.x) < 20) // right swipe
                {
                    if (rb.transform.position.x < 5.5)
                    {

                        rb.transform.position += new Vector3(1 * -(fp.x - lp.x)/20 * Time.deltaTime, 0, 0);

                    }


                }

            }
            /*
             if (touch.phase == TouchPhase.Ended)
             {
                  if ((fp.x - lp.x) > -20) // left swipe
                  {
                      rb.transform.position += new Vector3(-1 * 40 * Time.deltaTime, 0, 0);
                  }
                  else if ((fp.x - lp.x) < 20) // right swipe
                  {
                      rb.transform.position += new Vector3(1 * 40 * Time.deltaTime, 0, 0);
                  }

                  if ((fp.y - lp.y) < -3) // up swipe
                  {
                      if (isGrounded && increaseSize.canJump)
                      {

                          rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                          isGrounded = false;
                      }
                  }
        }
         }*/
        }
    }

    public void jumpPlayer()
    {
        rb.transform.Rotate(0, -18, 0);
        rb.transform.position = new Vector3(rb.transform.position.x + 3-size, rb.transform.position.y, rb.transform.position.z);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    } 
}
