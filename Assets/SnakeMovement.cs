using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidbody.AddForce(transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rigidbody.AddForce(transform.right * speed * Time.deltaTime*-1);
        }

    }
}
