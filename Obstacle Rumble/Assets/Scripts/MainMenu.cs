using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioSource click;
    [SerializeField] private RectTransform optionPanel;
    public void StartGame()
    {
        PlayerPrefs.SetInt("enemyCount", 0);
        PlayerPrefs.SetInt("playerCount", 0);
        PlayerPrefs.SetInt("totalScore", 0);
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        click.Play();
        optionPanel.localScale = new Vector3(1, 1, 1);

    }

    public void ExitGame()
    {
        click.Play();
        Application.Quit();
        Debug.Log("Game closed");
    }
}
