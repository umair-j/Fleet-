using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBottle : MonoBehaviour
{
    GameObject obj;
    private Transform bottle;
    // Start is called before the first frame update
    private void Awake()
    {
        obj = this.gameObject;
        bottle = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        bottle.Rotate(0, 0, 4);
    }

    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            obj.SetActive(false);
        }
    }
}
