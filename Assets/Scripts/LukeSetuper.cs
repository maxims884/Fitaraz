using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukeSetuper : MonoBehaviour
{
    // Start is called before the first frame update
    private System.Random rand = new System.Random();
    public GameObject other1;
    void Start()
    {
        if (getRand(0, 15) == 3 && !other1.transform.GetChild(0).gameObject.active) // Показывать ли Конус вообще
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
