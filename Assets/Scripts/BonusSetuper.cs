using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class BonusSetuper : MonoBehaviour
{
    //public TextMeshProUGUI text;
    public GameObject fuel;
    public GameObject bochka;
    private System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        //int rand = getRand(0, 2);
        //Debug.Log("rand = " + rand);
        if(getRand(0, 2) == 1) // Показывать ли бонус вообще
        {
            if (getRand(0, 4) == 3) // Определяем будем показывать Канистру или бочку (если 3 то бочку иначе конистра)
            {
                fuel.SetActive(false); 
                bochka.SetActive(true);
                bochka.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = getRand(-7, 3).ToString();
                bochka.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                fuel.SetActive(true);
                bochka.SetActive(false);
                fuel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = getRand(6, 11).ToString();
                fuel.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        } 
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
