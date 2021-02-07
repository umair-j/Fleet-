using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class increaseSize : MonoBehaviour
{
    public Transform jumpPosition;
    public static int levelNumber = 0;


    public Transform finishLineMarker;
    private static float finishLineZ;
    private float jumpLocationZ;
    private bool hasJumped;
    public static bool canJump;
    public GameObject animatedPlayer;
    public GameObject winScreen;
    public static bool hasWon = false;
    private Transform playerTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        finishLineZ = finishLineMarker.position.z;
        jumpLocationZ = jumpPosition.position.z;
        
        hasJumped = false;
        hasWon = false;
        winScreen.SetActive(false);
        playerTransform = GetComponent<Transform>();
    }
    void Start()
    {
        canJump = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "greenblock")
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x * 1.05f, playerTransform.localScale.y * 1.05f, playerTransform.localScale.z * 1.05f);
            playerMovement.speed += 1.3f;
            playerMovement.jumpForce += 2f;
            playerMovement.size -= 0.13f;
        }
       /* if (collision.collider.tag == "Finish")
        {
            hasWon = true;
            playerMovement.speed = 0;
            StartCoroutine(delay2sec());
        }
        if (collision.collider.tag == "jumper")
        {
            canJump = true;
            playerTransform.GetComponent<playerMovement>().jumpPlayer();
            
            animatedPlayer.GetComponent<Animator>().SetTrigger("isjumping");
        }
       */
    }
    IEnumerator delay2sec()
    {
        levelNumber++;
        yield return new WaitForSeconds(1);
        winScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelNumber);


    }
    
    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z >= jumpLocationZ && !hasJumped)
        {
            hasJumped = true;
            canJump = true;
            playerTransform.GetComponent<playerMovement>().jumpPlayer();

            animatedPlayer.GetComponent<Animator>().SetTrigger("isjumping");
        }
        if (playerTransform.position.z >= finishLineZ && !hasWon && playerTransform.position.y > 0)
        {
            hasWon = true;
            playerMovement.speed = 0;
            StartCoroutine(delay2sec());
        }
    }
}
