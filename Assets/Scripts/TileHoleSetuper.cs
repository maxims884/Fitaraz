using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHoleSetuper : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public GameObject other1;
    public GameObject other2;
    // Start is called before the first frame update
    void Start()
    {
        if (getRand(0, 3) == 1 && (other1.active || other2.active)) // Показывать ли бонус вообще
        {
            gameObject.SetActive(false);
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
