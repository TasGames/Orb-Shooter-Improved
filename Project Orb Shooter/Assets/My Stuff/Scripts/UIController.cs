using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] protected Image healthBar;
    [SerializeField] protected Text scoreText;
    [SerializeField] protected Text highScoreText;
    protected int highScore;

    void Start ()
    {

        //PlayerPrefs.Save;
    }
	
	void Update ()
    {
        healthBar.fillAmount = PlayerController.health / 100;
        if(PlayerController.health <= 0)
            SceneManager.LoadScene("Game Over");

        scoreText.text = "Score: " + Collisions.score;

        highScore = PlayerPrefs.GetInt("Highscore", highScore);

        if (Collisions.score > highScore)
        {
            highScore = Collisions.score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        highScoreText.text = "High-Score: " + PlayerPrefs.GetInt("Highscore", highScore);
    }
}
