using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    
    public float rotationSpeed = 3f;
    public float direction = 1f;
    
    void Update()
    {
        transform.Rotate(Vector3.left * direction, rotationSpeed * Time.deltaTime);
    }
}
