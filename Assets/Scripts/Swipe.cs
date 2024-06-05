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
    // Start is called before the first frame update
    void Start()
    {
        
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
                    Left();
                }

                if (endTouchPosition.x > startTouchPosition.x)
                {
                    Right();
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

    private void Left()
    {
        if (Player.transform.position.x > -1)
        {
            Vector3 targetPosition = new Vector3(Player.transform.position.x - 1.3f, Player.transform.position.y, Player.transform.position.z);
            StartCoroutine(MoveCube(targetPosition));
        }
    }

    IEnumerator MoveCube(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0;
        isDetectSwipe = false;
        while (timeElapsed < moveDuration)
        {
            Player.transform.position = Vector3.Lerp(startPosition,targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isDetectSwipe = true;
        Player.transform.position = targetPosition;
    }
}
