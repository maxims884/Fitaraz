using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonusSetuper : MonoBehaviour
{
    public TextMeshProUGUI text;
    private System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        text.text = getRand(5, 10).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int getRand(int minValue, int maxValue)
    {
        return rand.Next(minValue, maxValue);
    }
}
