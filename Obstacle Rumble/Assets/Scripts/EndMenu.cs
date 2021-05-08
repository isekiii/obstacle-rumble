using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private TMP_Text totalScore;
    public void ExitGame()
    { 
        click.Play();
        Application.Quit();
        Debug.Log("Game closed");
    }
    
    public void MainMenu()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        totalScore.text = PlayerPrefs.GetInt("totalScore").ToString();
    }
}
