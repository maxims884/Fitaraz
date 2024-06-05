using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Player : MonoBehaviour
{


    //private float countTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject coinCounter = GameObject.FindWithTag("Coin counter");
        int CurrentCoins = PlayerPrefs.GetInt("Coins");
        coinCounter.GetComponent<TextMeshProUGUI>().text = CurrentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //counttimer++;
        //if (counttimer > 500)
        //{
            //player.getcomponent<rigidbody>().usegravity = true;
        //}
    }

    private void OnCollisionEnter(Collision coll)
    {
        ObjectForce force = coll.gameObject.GetComponent<ObjectForce>();
        if (force)
        {
            GameObject scoreCounter = GameObject.FindWithTag("Score Counter");
            string[] words = scoreCounter.GetComponent<TextMeshProUGUI>().text.Split(' ');
            int minusValue = 1;
            int curretScore = Int32.Parse(words[1]);
            if (curretScore > 50) minusValue = 5;
            curretScore -= minusValue;
            if (curretScore < 0 ) curretScore = 0;
            scoreCounter.GetComponent<TextMeshProUGUI>().text = "Score: " + curretScore;
            force.OnHit();
        }
    }
}
