using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        speed = 20f;
     
       
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.right * Time.deltaTime*speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.left * Time.deltaTime*speed);
            }
             if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime*speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * Time.deltaTime*speed);
            }

    }
}
