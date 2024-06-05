using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSetuper : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject other1;
    private TileGenerator Generator;
    // Start is called before the first frame update
    void Start()
    {
        Generator = GameObject.Find("TileGenerator").GetComponent<TileGenerator>();
        float currentSpeed = Generator.GetCurrentSpeed();
        int RandMaxValue = 15;
        
        if(currentSpeed > 23) RandMaxValue = 13;
        if (currentSpeed > 25) RandMaxValue = 11;
        if (currentSpeed > 30) RandMaxValue = 7;

        if (currentSpeed > 21 && getRand(0, RandMaxValue) == 3 && !other1.transform.GetChild(0).gameObject.active) // Показывать ли Конус вообще
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private int getRand(int minValue, int maxValue)
    {
        return rand.Next(minValue, maxValue);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
