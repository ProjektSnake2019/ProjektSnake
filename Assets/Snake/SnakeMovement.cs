﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{

    public float targetSpeed;
    private float speed;
    public float rotationSpeed;
    public float slowdownAngle =40f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        moveForward();


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
        }
    }
    float innerSpeed;
    private void moveForward() 
    {
        
        if(transform.rotation.z > 0.5 || transform.rotation.z < -0.5)
        {
            Debug.Log(transform.rotation.z);
            transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,0);
        }

        if (transform.rotation.x > 0.5 || transform.rotation.x < -0.5)
        {
            Debug.Log(transform.rotation.x);
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        }
        innerSpeed = targetSpeed * (transform.localRotation.x/ slowdownAngle);
        if(-0.2f > innerSpeed)
        {
            Image Hbar = GameObject.Find("Hbar").GetComponent<Image>();
            Hbar.fillAmount -= 0.002f;
            if(Hbar.fillAmount == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
     
        speed = targetSpeed + innerSpeed;

        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
