using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioSource click;
    public void StartGame()
    {
        PlayerPrefs.SetInt("enemyCount", 0);
        PlayerPrefs.SetInt("playerCount", 0);
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        click.Play();
    }

    public void ExitGame()
    {
        click.Play();
        Application.Quit();
        Debug.Log("Game closed");
    }
}
