using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SnakeFragment : MonoBehaviour
{
    [SerializeField]
    private GameObject snakeFragmentPrefab;

    private GameObject gameobjectToFollow;
    Snake snake;

    // Start is called before the first frame update
    void Start()
    {
        snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<Snake>();
        gameobjectToFollow = snake.getObjectToFollow();
        snake.addObjectToFollow(gameObject);

        if (gameobjectToFollow != null)
        {
            followObject();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameobjectToFollow != null)
        {
            followObject();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Apple")
        {
            Text numberOfApples = GameObject.Find("ApplesNumber").GetComponent<Text>();
            snake.apples++;
            numberOfApples.text = "Apple: " + snake.apples;
            Destroy(collision.collider.gameObject);
            Instantiate(snakeFragmentPrefab, transform.parent);
        }
    }

    private void followObject() 
    {
        transform.LookAt(gameobjectToFollow.transform);

        float distance = Vector3.Distance(transform.position, gameobjectToFollow.transform.position);

        Debug.Log(distance);
        transform.position = Vector3.MoveTowards(transform.position, gameobjectToFollow.transform.position, distance*2 * Time.deltaTime);
    }
}
