using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text highscoreText;
    public GameObject GameOverScene;
    public AudioSource AddAudio;
    public AudioSource GameAudio;
    private void Start()
    {
        int s = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "High Score:" + s.ToString();
    }
    [ContextMenu("Increase Score")]
    public void add(int scoreToAdd)
    {
        score+= scoreToAdd;
        scoreText.text=score.ToString();
        //Debug.Log("adddddddd");
        AddAudio.Play();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOverWindow()
    {
        int currentHighScore = PlayerPrefs.GetInt("highscore");
        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "High Score:" + score.ToString();
        }
        GameOverScene.SetActive(true);

    }
}
