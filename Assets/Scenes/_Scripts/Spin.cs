using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public Vector3 rotationAmount;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = Quaternion.Euler(rotationAmount * rotationSpeed);
        transform.Rotate(rotationAmount * rotationSpeed);
    }
}
