using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField] float CarAceleration = 1f;

    float carSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        carSpeed += CarAceleration * Time.deltaTime; 
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        
    }
}
