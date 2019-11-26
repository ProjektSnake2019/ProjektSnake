using System.Collections;
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
