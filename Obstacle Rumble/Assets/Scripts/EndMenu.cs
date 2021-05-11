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
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text bestScore;
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

    public void EnterName()
    {
        if ( PlayerPrefs.GetInt("totalScore") > PlayerPrefs.GetInt("totalBest") )
        {
            PlayerPrefs.SetString("BestName", inputField.text);
            PlayerPrefs.SetInt("totalBest", PlayerPrefs.GetInt("totalScore"));
        }

        bestScore.text = $"Best player : {PlayerPrefs.GetString("BestName")}  -  {PlayerPrefs.GetInt("totalBest")}";
    }
    
    
    
}
