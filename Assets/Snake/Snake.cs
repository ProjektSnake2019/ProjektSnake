using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float apples;
    GameObject snakeFragments;
    void Start()
    {

    }

    public GameObject getObjectToFollow(){
        return snakeFragments;
    }
    public void addObjectToFollow(GameObject snakeFragment){
        snakeFragments = snakeFragment;
    }
}
