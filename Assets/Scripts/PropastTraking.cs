using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class PropastTraking : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject tileGenerator;
    [SerializeField] private GameObject camera;
    private float FallingThreshold = 0.6f;
    public TextMeshProUGUI playerText;
    private float countTimer = 0;
    private const float minDistance = 0.2f;

    private float cameraSpeed = 2f;

    private Vector3 targetCameraPosition = new Vector3(0, 10, -22);
    private bool isNeedMoveCamera = false;
    private System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isNeedMoveCamera)
        {
            Vector3 nextPositionCamera = Vector3.Lerp(camera.transform.position, targetCameraPosition, 0.04f);
            camera.transform.position = nextPositionCamera;
            if (camera.transform.position.y > 8.4 && camera.transform.position.y < 10)
            {
                isNeedMoveCamera = false;
                GameObject endGame = GameObject.FindWithTag("EndGame");
                if (endGame != null)
                {
                    GameObject scoreCounter = GameObject.FindWithTag("Score Counter");
                    string[] words = scoreCounter.GetComponent<TextMeshProUGUI>().text.Split(' ');
                    endGame.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = words[1]; //Score
                    scoreCounter.SetActive(false);

                    GameObject coinCounter = GameObject.FindWithTag("Coin counter");
                    coinCounter.GetComponent<TextMeshProUGUI>().enabled = true;
                    coinCounter.transform.parent.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    int HightsScore = Int32.Parse(words[1]);
                    int LastHightsScore = PlayerPrefs.GetInt("Hight Score");
                    if (HightsScore > LastHightsScore)
                    {
                        endGame.transform.GetChild(0).transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = HightsScore.ToString(); //Hight Score
                        PlayerPrefs.SetInt("Hight Score", HightsScore);
                    }
                    else
                    {
                        endGame.transform.GetChild(0).transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = LastHightsScore.ToString(); //Hight Score
                    }
                    endGame.GetComponent<Canvas>().enabled = true;

                    //-------Сколько заработал монеток-----------------
                    int EarnedCoins = 0;
                    EarnedCoins = HightsScore / 10;
                    int CurrentCoins = PlayerPrefs.GetInt("Coins");
                    PlayerPrefs.SetInt("Coins", CurrentCoins + EarnedCoins);
                    
                }
            }
        }
    }

    private float radius = 0.8f;
    private float forceValue = 15f;
    void OnTriggerStay(Collider other)
    {
       //взрыв моста

        if (other.CompareTag("lava")){
            if (countTimer > 11 && !tileGenerator.GetComponent<TileGenerator>().GetGenerate()) // 11 - промежуток через который снимается балл
            {
                countTimer = 0;
                int playerValue = Int32.Parse(playerText.text);

                
                int res = playerValue - 1;

                if (playerValue == 1)
                {
                    if ((player.transform.position -
                    (other.gameObject.transform.parent.gameObject.transform.position + Vector3.forward * (other.gameObject.transform.parent.gameObject.transform.localScale.z / 2))).sqrMagnitude <= minDistance * minDistance)
                    {
                        res = 1;
                    }
                }

                playerText.text = res.ToString();
                
                if(res <= 0)
                {
                    tileGenerator.GetComponent<TileGenerator>().SetPauseGenerate();
                    other.gameObject.GetComponent<Collider>().enabled = false;

                    isNeedMoveCamera = true;

                    Destrictible script = other.GetComponent<Destrictible>();
                    GameObject prefabPart = script.DestroyObj();

                    other.gameObject.transform.parent.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = false;
                    for (int i = 0; i < prefabPart.transform.childCount; i++)
                    {
                        GameObject child = prefabPart.transform.GetChild(i).gameObject;
                        Rigidbody rb = child.GetComponent<Rigidbody>();

                        if (rb != null)
                        {
                            Vector3 velocityT = new Vector3(0, 1, 0);
                            rb.AddForce(rand.Next(-10,10), rand.Next(0, 20), rand.Next(-10, 10), ForceMode.Impulse);
                        }
                    }
                }
            }
            countTimer++;
        }
    }

}
