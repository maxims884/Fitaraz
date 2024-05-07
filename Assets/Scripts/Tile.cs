using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed;
    private bool isPause = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isPause)
        transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
    }

    public void setPause() 
    { 
        isPause = true; 
    }

    public void setUnPause()
    {
        isPause = false;
    }
}
