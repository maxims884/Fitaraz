using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrikadaSetuper : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject other1;
    private TileGenerator Generator;
    void Start()
    {
        Generator = GameObject.Find("TileGenerator").GetComponent<TileGenerator>();
        if (Generator.GetCurrentSpeed() > 25 && getRand(0, 15) == 7 && !other1.transform.GetChild(0).gameObject.active) // Показывать ли Конус вообще
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
