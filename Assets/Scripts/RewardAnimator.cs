using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;
public class RewardAnimator : MonoBehaviour
{
    [SerializeField] private GameObject pileOfCoins;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Vector3[] initialPos;
    [SerializeField] private Quaternion[] initialRotation;
    private int coinsAmount =  14;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector3[coinsAmount];
        initialRotation = new Quaternion[coinsAmount];
        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            initialPos[i] = pileOfCoins.transform.GetChild(i).position;
            initialRotation[i] = pileOfCoins.transform.GetChild(i).rotation;
        }

        RewardPileOfCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reset()
    {
        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            pileOfCoins.transform.GetChild(i).position = initialPos[i];
            pileOfCoins.transform.GetChild(i).rotation = initialRotation[i];
        }
    }

    public void RewardPileOfCoin()
    {
        Reset();


        var delay = 0.5f;

        //pileOfCoins.SetActive(true);

        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            pileOfCoins.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector3(-390f, 1050f,400f), 1f)
            .SetDelay(delay + 0.5f).SetEase(Ease.OutBack);


            pileOfCoins.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);


            pileOfCoins.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 0.7f).SetEase(Ease.OutBack);

            delay += 0.1f;
        }

        //GameObject scoreCounter = GameObject.FindWithTag("Score Counter");
        //string[] words = counter.text.Split(' ');
        int resCoins = 0;
        resCoins = Int32.Parse(counter.text) * 5;
        StartCoroutine(CountCoins(resCoins));
    }

    IEnumerator CountCoins(int resCoins)
    {
        yield return new WaitForSecondsRealtime(0.9f);
        var timer = 0f;
        GameObject coinCounter = GameObject.FindWithTag("Coin counter");

        float step = (float)resCoins / (float)coinsAmount;

        for (int i = 0; i < coinsAmount; i++)
        {
            timer += 0.02f;

            float resStep = float.Parse(coinCounter.GetComponent<TextMeshProUGUI>().text) + step;
            coinCounter.GetComponent<TextMeshProUGUI>().text = ((int)Math.Round(resStep)).ToString();
            yield return new WaitForSecondsRealtime(timer);
        }

        coinCounter.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
