using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject Player;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float moveDuration = 0.10f;
    private bool isDetectSwipe = true;
    private TileGenerator Generator;

    private int CurrentSelectedCarIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Generator = GameObject.Find("TileGenerator").GetComponent<TileGenerator>();
        //PlayerPrefs.SetInt("Ñurrent selected car", 0);
        CurrentSelectedCarIndex = PlayerPrefs.GetInt("Ñurrent selected car");

        for (int i = 0; i < Player.transform.childCount; i++)
        {
            GameObject obj = Player.transform.GetChild(i).gameObject;
            Vector3 targetPosition = new Vector3(obj.transform.localPosition.x + 150f * CurrentSelectedCarIndex, obj.transform.localPosition.y, obj.transform.localPosition.z);
            StartCoroutine(MoveCubeInMenu(obj, targetPosition, 0f));
        }

    }

    void Update()
    {
        if (isDetectSwipe)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;
                if (endTouchPosition.x < startTouchPosition.x)
                {
                    if (!Generator.GetGenerate()) Left(); else LeftMenu();
                }

                if (endTouchPosition.x > startTouchPosition.x)
                {
                    if (!Generator.GetGenerate()) Right(); else RightMenu();
                }
            }
        }
    }
        private void Right()
    {
        if (Player.transform.position.x < 1)
        {
            Vector3 targetPosition = new Vector3(Player.transform.position.x + 1.3f, Player.transform.position.y, Player.transform.position.z);
            StartCoroutine(MoveCube(targetPosition));
        }
    }

    private void RightMenu()
    {
        float x = Player.transform.GetChild(0).transform.localPosition.x;
        if (x > 1)
        {
            for (int i = 0; i < Player.transform.childCount; i++)
            {
                GameObject obj = Player.transform.GetChild(i).gameObject;
                Vector3 targetPosition = new Vector3(obj.transform.localPosition.x - 150f, obj.transform.localPosition.y, obj.transform.localPosition.z);
                StartCoroutine(MoveCubeInMenu(obj, targetPosition, 0.2f));
            }
            CurrentSelectedCarIndex--;
            PlayerPrefs.SetInt("Ñurrent selected car", CurrentSelectedCarIndex);
        }
    }

    private void Left()
    {
        if (Player.transform.position.x > -1)
        {
            Vector3 targetPosition = new Vector3(Player.transform.position.x - 1.3f, Player.transform.position.y, Player.transform.position.z);
            StartCoroutine(MoveCube(targetPosition));
        }
    }

    private void LeftMenu()
    {
        float x = Player.transform.GetChild(Player.transform.childCount - 1).transform.localPosition.x;
        if (x < -1)
        {
            for (int i = 0; i < Player.transform.childCount; i++)
            {
                GameObject obj = Player.transform.GetChild(i).gameObject;
                Vector3 targetPosition = new Vector3(obj.transform.localPosition.x + 150f, obj.transform.localPosition.y, obj.transform.localPosition.z);
                StartCoroutine(MoveCubeInMenu(obj, targetPosition,0.2f));
            }
            CurrentSelectedCarIndex++;
            PlayerPrefs.SetInt("Ñurrent selected car", CurrentSelectedCarIndex);
        }
    }

    IEnumerator MoveCube(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0;
        isDetectSwipe = false;
        while (timeElapsed < moveDuration)
        {
            Player.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isDetectSwipe = true;
        Player.transform.position = targetPosition;
    }

    IEnumerator MoveCubeInMenu(GameObject obj, Vector3 targetPosition, float moveDurationMenu)
    {
        Vector3 startPosition = obj.transform.localPosition;
        float timeElapsed = 0;
        isDetectSwipe = false;
        while (timeElapsed < moveDurationMenu)
        {
            obj.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDurationMenu);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isDetectSwipe = true;
        obj.transform.localPosition = targetPosition;
    }
}
