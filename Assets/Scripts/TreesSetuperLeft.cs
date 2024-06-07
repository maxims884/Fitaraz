using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TreesSetuperLeft : MonoBehaviour
{
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        int x = getRand(-5, -3);
        int z = getRand(-4, 4);
        transform.GetChild(0).gameObject.SetActive(true);
        float scaleFactor = getRand(1, 4) / 2.0f;
        transform.GetChild(0).transform.localPosition = new Vector3(x, 0, z);
        transform.GetChild(0).transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
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
