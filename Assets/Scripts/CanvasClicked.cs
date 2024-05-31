using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 1




public class CanvasClicked : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject tileGenerator;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject pauseGame = GameObject.FindWithTag("Pause Game");
        if (pauseGame != null)
        {
            GameObject pauseButton = pauseGame.transform.GetChild(1).gameObject;
            pauseButton.SetActive(true);

            GameObject pausePanel = pauseGame.transform.GetChild(0).gameObject;
            pausePanel.SetActive(false);

            GameObject pausePanel2 = pauseGame.transform.GetChild(2).gameObject;
            pausePanel2.SetActive(false);

            GameObject currentScore = pauseGame.transform.GetChild(3).gameObject;
            currentScore.SetActive(true);

            tileGenerator.GetComponent<TileGenerator>().SetStartGenerate();

        }
    }
}
 