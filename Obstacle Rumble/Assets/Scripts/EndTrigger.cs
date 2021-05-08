using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject player, enemy, playerSpawn, enemySpawn;
    [SerializeField] private GameObject health0, health30, health70, health100;
    [SerializeField] private GameObject Ehealth0, Ehealth30, Ehealth70, Ehealth100;
    private int playerCount =0;
    private int enemyCount =0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount++;
            audio.Play();
            StartCoroutine(Respawn());

        }
        if (other.tag == "Enemy")
        {
            enemyCount++;
            audio.Play();
            StartCoroutine(Respawn());
            
        }
    }

    private void Update()
    {
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
        
        if (enemyCount == 1)
        {
            Ehealth100.SetActive(false);
            Ehealth70.SetActive(true);
        }
        if (enemyCount == 2)
        {
            Ehealth70.SetActive(false);
            Ehealth30.SetActive(true);
        }
        if (enemyCount == 3)
        {
            Ehealth30.SetActive(false);
            Ehealth0.SetActive(true);
        }

        if (playerCount == 3)
        {
            StartCoroutine(RestartLevel());
        }
        if (enemyCount == 3)
        {
            StartCoroutine(RestartLevel());
        }
    }


    private IEnumerator RestartLevel()
    {
        endText.text = "GAME OVER";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator Respawn()
    {
        
        yield return new WaitForSeconds(2f);
        player.transform.Translate(playerSpawn.transform.position);
        enemy.transform.Translate(enemySpawn.transform.position);

    }
    
}
