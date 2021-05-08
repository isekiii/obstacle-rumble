using System.Collections;
using UnityEngine;

public class ObstacleSwing : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float direction = 1f;
    public float timer = 1; //cia nustatysi kas kiek laiko kryptis keisis

    private void Start()
    {
        StartCoroutine(ChangeDir());
    }

    void Update()
    {
        transform.Rotate(Vector3.left * direction, rotationSpeed * Time.deltaTime);
    }

    IEnumerator ChangeDir()
    {
        yield return new WaitForSeconds(timer);
        direction *= -1;
        StartCoroutine(ChangeDir());
    }
}
