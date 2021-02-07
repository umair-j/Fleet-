using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class celebration : MonoBehaviour
{
   
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseSize.hasWon)
        {
            //anim.SetBool("isRunning", false);
            anim.SetTrigger("won");
            //anim.SetBool("Won", true);
            //anim.Play("Victory");
        }
        
    }
    
}
