using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highestScoreText;
    [SerializeField] GameObject endGameScreen;
    public static SceneController sceneController;
    private int score;
    private int highScore;
    private float ballLifeTime = 4f;
    private float timeBeetweenSpanw = 4f;
    [SerializeField] float timeToEncreaseDifficulty = 5f;
    private float timeSinceLastDifficultyEncrease = 0;


    public float BallLifeTime { get => ballLifeTime; set => ballLifeTime = value; }
    public float TimeBeetweenSpanw { get => timeBeetweenSpanw; set => timeBeetweenSpanw = value; }

    private void Awake()
    {
        sceneController = this;
    }
    void Start()
    {
        endGameScreen.SetActive(false);
        Time.timeScale = 1;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        scoreText.text = "Score: " + score;
    }
    private void Update()
    {
        if(timeSinceLastDifficultyEncrease > timeToEncreaseDifficulty)
        {
            timeSinceLastDifficultyEncrease = 0;
            if(BallLifeTime < 1f)
            {
                BallLifeTime -= 0.1f;
            }
            else if(BallLifeTime <= .5f)
            {
                BallLifeTime = 0.5f;
            }
            if(TimeBeetweenSpanw <= 0.25f)
            {
                TimeBeetweenSpanw = 0.25f;
            }
            BallLifeTime -= 0.25f;
            TimeBeetweenSpanw -= 0.25f;

        }
        timeSinceLastDifficultyEncrease += Time.deltaTime;
    }

    public void AddToScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
    public void ShowHighestScore()
    {
        endGameScreen.SetActive(true);
        highestScoreText.text = "Your score is: " + score;
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highestScoreText.text += "    Congratulations! You have set new highest score! " + score;
        }
        else
        {
            highestScoreText.text += "    Highest score is: " + highScore + ". Try one more time!"; 
        }
    }
    public void Restart()
    {
        BallLifeTime = 4f;
        SceneManager.LoadScene(1);
    }
}
