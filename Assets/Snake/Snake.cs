using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float apples;
    private Stack<GameObject> snakeFragments = new Stack<GameObject>();

    void Start()
    {

    }

    public GameObject getObjectToFollow() 
    {
        if (snakeFragments.Count != 0)
        {
            return snakeFragments.Pop();
        }
        else
        {
            return null;
        }
    }
    public void addObjectToFollow(GameObject snakeFragment)
    {
        snakeFragments.Push(snakeFragment);
    }
}
