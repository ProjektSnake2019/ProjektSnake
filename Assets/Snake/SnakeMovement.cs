using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public float targetSpeed;
    private float speed;
    public float rotationSpeed;
    public float slowdownAngle = 0.4f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        moveForward();

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
        }
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
        innerSpeed = speed * transform.rotation.x/ slowdownAngle;
        speed = targetSpeed + innerSpeed;

        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
