using UnityEngine;
using UnityEngine.UI;

public class SaveHighscore : MonoBehaviour
{
    private float lastScore;
    public Text highscore;
    public Score sc;

    void Start()
    {
        sc.isPlayerActive = true;
        SetCurrentScore();
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        
    }

    void SetCurrentScore()
    {
        lastScore = sc.maxScore;
        Debug.Log(lastScore);
        if (lastScore > PlayerPrefs.GetInt("HighScore", (int)lastScore))
        {
            PlayerPrefs.SetInt("HighScore", (int)lastScore);
            highscore.text = lastScore.ToString();
        }
       
    }
}
