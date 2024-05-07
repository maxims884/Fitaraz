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

    // Update is called once per frame
    void Update()
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
        isNeedMoveCamera = true; // Движение камеры
        tileGenerator.GetComponent<TileGenerator>().SetStartGenerate();
    }
}
