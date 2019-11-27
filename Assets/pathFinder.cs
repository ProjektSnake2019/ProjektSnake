using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathFinder : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject[] apples;
    public GameObject[] snake;
    public GameObject nearestPoint;

    // Update is called once per frame
    void Update()
    {
        float distance = 0; ;
        apples = GameObject.FindGameObjectsWithTag("Apple");
        snake = GameObject.FindGameObjectsWithTag("Snake");


        if (Input.GetMouseButtonDown(0))
        {

            float min = Vector3.Distance(apples[0].transform.position, snake[0].transform.position);

            foreach (GameObject positionApple in apples)
            {
                distance = Vector3.Distance(positionApple.transform.position, snake[0].transform.position);

                if (distance < min)
                {
                    min = distance;
                    nearestPoint = positionApple;
                }
            }

            agent.SetDestination(nearestPoint.transform.position);
 
        }
    }

}
