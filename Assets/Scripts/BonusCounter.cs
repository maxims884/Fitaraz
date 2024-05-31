using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq.Expressions;

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
            GameObject child1;
            if (other.transform.GetChild(0).gameObject.active == true)
            {
                child1 = other.transform.GetChild(0).gameObject;
            }
            else { 
                child1 = other.transform.GetChild(1).gameObject;
            }

            GameObject child2 = child1.transform.GetChild(0).gameObject;
            string text = child2.GetComponent<TextMeshProUGUI>().text;
            //Debug.Log("On Trigger Bonus " + text);
            if( text != "")
            {
                int value = Int32.Parse(text);
                int playerValue = Int32.Parse(playerText.text);
                int res = playerValue + value;

                if (res <= 0)
                {
                    res = 0;
                }

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
                                if (child.transform.GetChild(0).gameObject.active)
                                {
                                    GameObject subChild1 = child.transform.GetChild(0).gameObject;
                                    GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                                    subChild2.GetComponent<TextMeshProUGUI>().text = "";
                                }
                                else
                                {
                                    GameObject subChild1 = child.transform.GetChild(1).gameObject;
                                    GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                                    subChild2.GetComponent<TextMeshProUGUI>().text = "";
                                }
                            };
                        }
                        break;
                    case "CubeCenter":
                        for (int i = 0; i < other.gameObject.transform.parent.transform.childCount; i++)
                        {
                            GameObject child = other.gameObject.transform.parent.GetChild(i).gameObject;
                            if (child.name == "CubeRight" || child.name == "CubeLeft")
                            {
                                if (child.transform.GetChild(0).gameObject.active)
                                {
                                    GameObject subChild1 = child.transform.GetChild(0).gameObject;
                                    GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                                    subChild2.GetComponent<TextMeshProUGUI>().text = "";
                                } else
                                {
                                    GameObject subChild1 = child.transform.GetChild(1).gameObject;
                                    GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                                    subChild2.GetComponent<TextMeshProUGUI>().text = "";
                                }
                            };
                        }
                        break;
                    case "CubeLeft":
                        for (int i = 0; i < other.gameObject.transform.parent.transform.childCount; i++)
                        {
                            GameObject child = other.gameObject.transform.parent.GetChild(i).gameObject;
                            if (child.name == "CubeCenter" || child.name == "CubeRight")
                            {
                                if (child.transform.GetChild(0).gameObject.active)
                                {
                                    GameObject subChild1 = child.transform.GetChild(0).gameObject;
                                    GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                                    subChild2.GetComponent<TextMeshProUGUI>().text = "";
                                }
                                else
                                {
                                    GameObject subChild1 = child.transform.GetChild(1).gameObject;
                                    GameObject subChild2 = subChild1.transform.GetChild(0).gameObject;
                                    subChild2.GetComponent<TextMeshProUGUI>().text = "";
                                }
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
}
