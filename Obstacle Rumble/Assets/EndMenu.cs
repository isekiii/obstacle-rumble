using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private AudioSource click;
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
}
