using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    
    public Transform Obj;
    public float rotationSpeed = 3f;
    
    void Update()
    {
        Obj.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
