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
    [SerializeField] private TMP_Text bestScore1,bestScore2,bestScore3, newHS;
    [SerializeField] private GameObject inputBtn;


    private string h1, h2, h3;
    private int s1, s2, s3;
    
    
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
        h1 = PlayerPrefs.GetString("BestName1");
        h2 = PlayerPrefs.GetString("BestName2");
        h3 = PlayerPrefs.GetString("BestName3");
        s1 = PlayerPrefs.GetInt("BestScore1");
        s2 = PlayerPrefs.GetInt("BestScore2");
        s3 = PlayerPrefs.GetInt("BestScore3");
        
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PrintScores();
        
        totalScore.text = PlayerPrefs.GetInt("totalScore").ToString();
    }

    public void EnterName()
    {
        /*
        if ( PlayerPrefs.GetInt("totalScore") > PlayerPrefs.GetInt("totalBest") )
        {
            PlayerPrefs.SetString("BestName", inputField.text);
            PlayerPrefs.SetInt("totalBest", PlayerPrefs.GetInt("totalScore"));
        }

        bestScore1.text = $"Best player : {PlayerPrefs.GetString("BestName")}  -  {PlayerPrefs.GetInt("totalBest")}";
        */
        
        UpdateHS();
        SetScores();
        PrintScores();
        inputBtn.SetActive(false);
        
    }


    void UpdateHS()
    {
        int current = PlayerPrefs.GetInt("totalScore");

        if (current > s1)
        {
            newHS.text = "new highscore!";
            s3 = s2;
            h3 = h2;
            s2 = s1;
            h2 = h1;
            s1 = current;
            h1 = inputField.text;
        }
        else if (current > s2)
        {
            newHS.text = "new highscore!";
            s3 = s2;
            h3 = h2;
            s2 =  current;
            h2 = inputField.text;
        }
        else if (current > s3)
        {
            newHS.text = "new highscore!";
            s3 =  current;
            h3 = inputField.text;
        }
        else newHS.text = "";
    }

    void SetScores()
    {
        PlayerPrefs.SetString("BestName1",h1);
        PlayerPrefs.SetString("BestName2",h2);
        PlayerPrefs.SetString("BestName3",h3);
        PlayerPrefs.SetInt("BestScore1",s1);
        PlayerPrefs.SetInt("BestScore2",s2);
        PlayerPrefs.SetInt("BestScore3",s3);
        
        
        
    }

    void PrintScores()
    {
        bestScore1.text = $"{h1}    {s1}";
        bestScore2.text = $"{h2}    {s2}";
        bestScore3.text = $"{h3}    {s3}";
    }



}
