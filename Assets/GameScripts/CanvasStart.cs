using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasStart : MonoBehaviour
{
    public Canvas canvas;
    public Camera mainCamera;
    public Vector3 cameraPosition;
    public TMP_Text scoreText;
    void Start()
    {
        Debug.Log("Canvas Start");
        canvas.enabled = true;
        cameraPosition = new Vector3(13.29f, 8.42f, 0.27f);
        mainCamera.transform.position = cameraPosition;
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        scoreText.text = 0 + " - " + 0;
        Debug.Log("Camera Position: " + mainCamera.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
