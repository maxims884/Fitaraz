using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Player : MonoBehaviour
{
    private TileGenerator Generator;
    private float countTimer = 0;
    //Vector3 targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        Generator = GameObject.Find("TileGenerator").GetComponent<TileGenerator>();
        GameObject coinCounter = GameObject.FindWithTag("Coin counter");
        int CurrentCoins = PlayerPrefs.GetInt("Coins");
        coinCounter.GetComponent<TextMeshProUGUI>().text = CurrentCoins.ToString();
        //targetRotation = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!Generator.GetGenerate())
        {
            if (countTimer % 70 == 0)
            {
                DecreaseFuel();
            }
            countTimer++;
        }

        //Debug.Log("DDD " + Math.Abs(transform.localRotation.eulerAngles.x - targetRotation.x));
        //Debug.Log("DDD1 " + Math.Abs(transform.localRotation.eulerAngles.x));
        //Debug.Log("DDD2 " + Math.Abs(targetRotation.x));
        //if (Math.Abs(transform.localRotation.eulerAngles.x - targetRotation.x) > 5 || Math.Abs(transform.localRotation.eulerAngles.y - targetRotation.y) > 5 || Math.Abs(transform.localRotation.eulerAngles.z - targetRotation.z) > 5)
        //{
        //    StartCoroutine(levelingRotation(targetRotation, 1f));
        //}
    }

    private void OnCollisionEnter(Collision coll)
    {
        ObjectForce force = coll.gameObject.GetComponent<ObjectForce>();
        if (force)
        {
            GameObject scoreCounter = GameObject.FindWithTag("Score Counter");
            string[] words = scoreCounter.GetComponent<TextMeshProUGUI>().text.Split(' ');
            int minusValue = 3;
            int curretScore = Int32.Parse(words[1]);
            if (curretScore > 50) minusValue = 5;
            curretScore -= minusValue;
            if (curretScore < 0 ) curretScore = 0;
            scoreCounter.GetComponent<TextMeshProUGUI>().text = "Score: " + curretScore;
            force.OnHit();
        }
    }

    private void DecreaseFuel()
    {
        int playerValue = Int32.Parse(transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) - 1;
        transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerValue.ToString();
    }

    //IEnumerator levelingRotation(Vector3 targetRotation, float duration)
    //{
    //    Vector3 startRotation = transform.localRotation.eulerAngles;
    //    float timeElapsed = 0;

    //    while (timeElapsed < duration)
    //    {
    //        transform.localRotation = Quaternion.Euler(Vector3.Lerp(startRotation, targetRotation, timeElapsed / duration));
    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.localRotation = Quaternion.Euler(targetRotation);
    //}

}
