using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class Tile : MonoBehaviour
{
    public float speed;
    private bool isPause = false;
    private bool isNeedAddScore = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPause)
        {
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
            if (isNeedAddScore && 2.66f < transform.position.z + 0.1f && transform.position.z - 0.1f < 2.66f) // 2.66 положение машины по Z
            {
                isNeedAddScore = false;
                GameObject scoreCounter = GameObject.FindWithTag("Score Counter");
                string[] words = scoreCounter.GetComponent<TextMeshProUGUI>().text.Split(' ');
                int score = Int32.Parse(words[1]) + 1;
                scoreCounter.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
            }
        }
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
