using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBSetupper : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject other1;
    public GameObject other2;
    private TileGenerator Generator;
    // Start is called before the first frame update
    void Start()
    {
        Generator = GameObject.Find("TileGenerator").GetComponent<TileGenerator>();
        if ( getRand(0, 2) == 1 && !other1.transform.GetChild(0).gameObject.active && !other2.transform.GetChild(0).gameObject.active) // Показывать ли Конус вообще
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
