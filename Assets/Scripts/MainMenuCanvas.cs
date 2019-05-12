using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] Text highestScoreText;
    private int highScore = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
            highestScoreText.text = "The Highest Score: " + highScore;

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
