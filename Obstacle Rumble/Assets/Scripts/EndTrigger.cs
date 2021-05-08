using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject health0, health30, health70, health100;
    [SerializeField] private GameObject eHealth0, eHealth30, eHealth70, eHealth100;
    private int playerCount =0;
    private int enemyCount =0;

    private void Start()
    {
        playerCount = PlayerPrefs.GetInt("playerCount");
        enemyCount = PlayerPrefs.GetInt("enemyCount");
        UpdateHealth();
        
    }


    void UpdateHealth()
    {
        if (playerCount == 0)
        {
            health100.SetActive(true);
        }
        
        if (playerCount == 1)
        {
            health100.SetActive(false);
            health70.SetActive(true);
        }
        if (playerCount == 2)
        {
            health70.SetActive(false);
            health30.SetActive(true);
        }
        if (playerCount == 3)
        {
            health30.SetActive(false);
            health0.SetActive(true);
        }
        
        if (enemyCount == 0)
        {
            eHealth100.SetActive(true);
        }
        if (enemyCount == 1)
        {
            eHealth100.SetActive(false);
            eHealth70.SetActive(true);
        }
        if (enemyCount == 2)
        {
            eHealth70.SetActive(false);
            eHealth30.SetActive(true);
        }
        if (enemyCount == 3)
        {
            eHealth30.SetActive(false);
            eHealth0.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Player count : {playerCount}    Enemy count : {enemyCount}");
        if (other.tag == "PlayerBody")
        {
            playerCount++;
            PlayerPrefs.SetInt("playerCount", playerCount);
            audio.Play();
            UpdateHealth();
           StartCoroutine(RestartLevel());

        }
        if (other.tag == "EnemyBody")
        {
            enemyCount++;
            PlayerPrefs.SetInt("enemyCount", enemyCount);
            audio.Play();
            UpdateHealth();
            StartCoroutine(RestartLevel());
            
        }
    }

    private void Update()
    {
        if (playerCount == 3)
        {
            StartCoroutine(EndLevel());
        }
        
        if (enemyCount == 3)
        {
            StartCoroutine(EndLevel());
        }
       

    }


    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator EndLevel()
    {
        if (playerCount > enemyCount)
        {
            endText.text = "GAME OVER";
        }
        else endText.text = "VICTORY";
        
        yield return new WaitForSeconds(2f);
        endText.text = "";
        PlayerPrefs.SetInt("enemyCount", 0);
        PlayerPrefs.SetInt("playerCount", 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    
    
}
