using System.Collections;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(endEffect());
    }

    IEnumerator endEffect()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
