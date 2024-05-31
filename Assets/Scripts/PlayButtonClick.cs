using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayButtonClick : MonoBehaviour
{
    private float cameraSpeed = 0.6f;
    private Vector3 targetCameraPosition = new Vector3(0, 3.7f, -3.3f);
    private bool isNeedMoveCamera = false;
    [SerializeField] private GameObject camera;
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private GameObject tileGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector2 endTouchPosition;
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isNeedMoveCamera)
        {
            Vector3 nextPositionCamera = Vector3.Lerp(camera.transform.position, targetCameraPosition, Time.deltaTime * cameraSpeed);
            camera.transform.position = nextPositionCamera;
            if (camera.transform.position.y > 3.6 && camera.transform.position.y < 3.8) isNeedMoveCamera = false;
        }
    }
    public void onPlayClicked()
    {
        GetComponent<Image>().enabled = false; // Отключение кнопки плэй
        playerText.text = "0"; // Установка начального значения
        GameObject FuelIcon = GameObject.FindWithTag("Fuel icon");
        FuelIcon.GetComponent<Image>().enabled = true;
        isNeedMoveCamera = true; // Движение камеры
        tileGenerator.GetComponent<TileGenerator>().SetStartGenerate();

        GameObject pauseGame = GameObject.FindWithTag("Pause Game");
        if (pauseGame != null)
        {
            GameObject pauseButton = pauseGame.transform.GetChild(1).gameObject;
            GameObject scoreText = pauseGame.transform.GetChild(3).gameObject;
            pauseGame.transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().enabled = false;
            GameObject coinCounter = GameObject.FindWithTag("Coin counter");
            coinCounter.GetComponent<TextMeshProUGUI>().enabled = false;

            pauseButton.SetActive(true);
            scoreText.SetActive(true);
            
        }
    }
    public void onRetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onPauseClicked()
    {
        GameObject pauseGame = GameObject.FindWithTag("Pause Game");
        if (pauseGame != null && !tileGenerator.GetComponent<TileGenerator>().GetGenerate())
        {
            tileGenerator.GetComponent<TileGenerator>().SetPauseGenerate();
            GameObject pauseButton = pauseGame.transform.GetChild(1).gameObject;
            pauseButton.SetActive(false);

            GameObject pausePanel = pauseGame.transform.GetChild(0).gameObject;
            pausePanel.SetActive(true);

            GameObject pausePanel2 = pauseGame.transform.GetChild(2).gameObject;
            pausePanel2.SetActive(true);

            GameObject scoreCounter = GameObject.FindWithTag("Score Counter");
            string[] words = scoreCounter.GetComponent<TextMeshProUGUI>().text.Split(' ');
            pausePanel2.transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = words[1];

            pausePanel2.transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Hight Score").ToString();

            GameObject currentScore = pauseGame.transform.GetChild(3).gameObject;
            currentScore.SetActive(false);
        }
    }

    public void onResumeClicked()
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
