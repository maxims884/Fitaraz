using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player;

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
}
