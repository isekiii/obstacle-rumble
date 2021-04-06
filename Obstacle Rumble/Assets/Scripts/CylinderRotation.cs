using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    
    
    public float rotationSpeed = 3f;
    public float direction = 1f;

   // private Vector3 rotationDir;
    private void Start()
    {
       // rotationDir = new Vector3(direction, 0, 0);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * direction, rotationSpeed * Time.deltaTime);
    }
}
        
    

