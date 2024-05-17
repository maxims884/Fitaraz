using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq.Expressions;
using System.Diagnostics;

public class BonusCounter : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    // Start is called before the first frame update
    void Start()
    {
        playerText.text =  "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CubeRight" || other.gameObject.name == "CubeCenter" || other.gameObject.name == "CubeLeft"){
            GameObject child1 = other.transform.GetChild(0).gameObject;
            GameObject child2 = child1.transform.GetChild(0).gameObject;
            string text = child2.GetComponent<TextMeshProUGUI>().text;
            //Debug.Log("On Trigger Bonus " + text);
            int value = Int32.Parse(text);
            int playerValue = Int32.Parse(playerText.text);
            int res = playerValue + value;
            playerText.text = res.ToString();
            Destroy(other.gameObject);

            switch (other.gameObject.name)
            {
                case "CubeRight":
                    for (int i = 0; i < other.gameObject.transform.parent.transform.childCount; i++)
                    {
                        GameObject child = other.gameObject.transform.parent.GetChild(i).gameObject;
                        if (child.name == "CubeCenter" || child.name == "CubeLeft")
                        {
                            GameObject subChild1 = child.transform.GetChild(0).gameObject;
                            GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                            subChild2.GetComponent<TextMeshProUGUI>().text = "0";
                        };
                    }
                    break;
                case "CubeCenter":
                    for (int i = 0; i < other.gameObject.transform.parent.transform.childCount; i++)
                    {
                        GameObject child = other.gameObject.transform.parent.GetChild(i).gameObject;
                        if (child.name == "CubeRight" || child.name == "CubeLeft")
                        {
                            GameObject subChild1 = child.transform.GetChild(0).gameObject;
                            GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                            subChild2.GetComponent<TextMeshProUGUI>().text = "0";
                        };
                    }
                    break;
                case "CubeLeft":
                    for (int i = 0; i < other.gameObject.transform.parent.transform.childCount; i++)
                    {
                        GameObject child = other.gameObject.transform.parent.GetChild(i).gameObject;
                        if (child.name == "CubeCenter" || child.name == "CubeRight")
                        {
                            GameObject subChild1 = child.transform.GetChild(0).gameObject;
                            GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                            subChild2.GetComponent<TextMeshProUGUI>().text = "0";
                        };
                    }
                    break;

                default:
                    // code block
                    break;
            }
        }
    }
}
