using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{
    [SerializeField] private AudioSource click;

    public void MainMenu()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
