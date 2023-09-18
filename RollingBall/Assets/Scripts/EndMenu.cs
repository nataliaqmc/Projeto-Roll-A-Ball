using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreText;
    public void Start ()
    {
    	highscoreText.text = "Best time: " + PlayerPrefs.GetInt("HighScoreMinutes",0).ToString("0") + " min " + PlayerPrefs.GetFloat("HighScoreTime",0).ToString("0") + "s";
    	scoreText.text = "Your time: " + PlayerPrefs.GetInt("ScoreMinutes",0).ToString("0") + " min " + PlayerPrefs.GetFloat("ScoreTime",0).ToString("0") + "s";
    }
    public void PlayGame () 
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
