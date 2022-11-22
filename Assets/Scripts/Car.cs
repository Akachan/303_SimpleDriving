using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float carSpeed= 1f;
    [SerializeField] float carAceleration = 2f;
    [SerializeField] float rotationSpeed = 20f;

    int steerValue;  //para validar si debe ser + o -



   
    void Update()
    {
        carSpeed += carAceleration * Time.deltaTime; 

        transform.Rotate(0f, steerValue * rotationSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        
    }
    public void Steer (int value)
    {
        steerValue = value;
    }
    }
