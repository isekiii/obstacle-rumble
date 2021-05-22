using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "L E V E L   "  + SceneManager.GetActiveScene().buildIndex +  " \n k n o c k   o f f   y o u r    o p p o n e n t";
        StartCoroutine(time());
    }


    public IEnumerator time()
    {
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }
}
