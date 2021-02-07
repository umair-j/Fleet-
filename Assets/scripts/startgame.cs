using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : MonoBehaviour
{
    public GameObject menu;
    private Animator anim;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        playerMovement.isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            menu.SetActive(false);
            anim.SetTrigger("isrunning");
            //anim.SetBool("isRunning", true);
            //anim.Play("Running");
            playerMovement.isActive = true;
        }
    }
}
