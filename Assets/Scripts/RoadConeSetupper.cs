using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadConeSetupper : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject other1;
    public GameObject other2;
    private TileGenerator Generator;
    // Start is called before the first frame update
    void Start()
    {
        Generator = GameObject.Find("TileGenerator").GetComponent<TileGenerator>() ;
        if (Generator.GetCurrentSpeed() > 19 && getRand(0, 2) == 1 && !other1.GetComponent<MeshRenderer>().enabled && !other2.GetComponent<MeshRenderer>().enabled) // Показывать ли Конус вообще
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
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