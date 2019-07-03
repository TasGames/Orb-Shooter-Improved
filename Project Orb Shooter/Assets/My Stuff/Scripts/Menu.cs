using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] protected  AudioClip select;

    void Start()
    {
        GetComponent<AudioSource>().clip = select;
    }
    public void play()
    {
        SceneManager.LoadScene("Main");
        Collisions.score = 0;
        Pause.isPaused = false;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Intro Screen");
        Collisions.score = 0;
        Pause.isPaused = false;
    }

    public void Preturn()
    {
        GetComponent<AudioSource>().Play();
        Pause.isPaused = false;
    }

    public void how()
    {
        SceneManager.LoadScene("How To Play");
        Collisions.score = 0;
        Pause.isPaused = false;
    }

    public void sound()
    {
        GetComponent<AudioSource>().Play();
    }

}
