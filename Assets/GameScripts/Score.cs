using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText; 
    private int playerScore = 0;
    private int goalkeeperScore = 0;
    public Canvas canvas;
    public Camera mainCamera;
    public Vector3 cameraPosition;

    void Start()
    {
        //scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        //UpdateScoreText();
    }

    // Function to increment player score
    public void IncrementPlayerScore()
    {
        playerScore++;
        UpdateScoreText();
    }

    // Function to increment goalkeeper score
    public void IncrementGoalkeeperScore()
    {
        goalkeeperScore++;
        UpdateScoreText();
    }

    // Update the UI text element to display the scores
    void UpdateScoreText()
    {
        scoreText.text = playerScore + " - " + goalkeeperScore;
    }

    public void StartGame()
    {
        Debug.Log("Canvas Start");
        canvas.gameObject.SetActive(true);
        cameraPosition = new Vector3(13.29f, 8.42f, 0.27f);
        mainCamera.transform.position = cameraPosition;
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        scoreText.text = playerScore + " - " + goalkeeperScore;
        Debug.Log("Camera Position: " + mainCamera.transform.position);
    }

}
