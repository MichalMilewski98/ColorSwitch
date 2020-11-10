using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform playerTransform;
    public Text scoreText;
    public float maxScore;
    private float currentScore;
    public bool isPlayerActive;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        GetMaxScore();
        SetScore();
    }

    private void GetMaxScore()
    {
        if (!isPlayerActive)
        {
            currentScore = playerTransform.position.y;
            if (maxScore < currentScore)
                maxScore = currentScore;
        }
        
    }

    private void SetScore()
    {
        if (!isPlayerActive)
        {
            if (playerTransform.position.y < 0)
                scoreText.text = "0";
            else
                scoreText.text = maxScore.ToString("0");
        }
    }
}