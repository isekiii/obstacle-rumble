using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Console : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_InputField input;


    private bool isOn;

    private void Start()
    {
        isOn = false;
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("Pressed F2");
            if (isOn)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                isOn = false;
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                isOn = true;
                panel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            Command(input.text);
        }
    }

    void Command(string command)
    {
        char[] sep = {' '};
        string[] parts = command.Split(sep);
        
        
        if (command.Equals("/load next", StringComparison.OrdinalIgnoreCase))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else if (command.Equals("/load menu", StringComparison.OrdinalIgnoreCase))
        {
            SceneManager.LoadScene(0);
        }
        else if (parts[0].Equals("/totalscore", StringComparison.OrdinalIgnoreCase))
        {
            int nr = Int32.Parse(parts[1]);
            PlayerPrefs.SetInt("totalScore", nr);
        }
        
        else Debug.Log("Wrong command");
    }
}
