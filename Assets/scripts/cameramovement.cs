using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    private float lastposition;
    public static bool stop = false;
    private Transform t;
    public Transform camera;
    // Start is called before the first frame update
    private void Awake()
    {
        t = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            t.position = new Vector3(0f, 5f, lastposition );
        }
            t.position = new Vector3(0f, 5f, t.position.z);
            if (t.position.y < -1)
            {
            lastposition = t.position.z;
                stop = true;
                camera.position = new Vector3(t.position.x, 4, t.position.z);
            }

        
    }
    
}
