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
        if (collision.collider.tag == "Apple")
        {
            Text numberOfApples = GameObject.Find("ApplesNumber").GetComponent<Text>();
            snake.apples++;
            numberOfApples.text = snake.apples.ToString();

            Image Hbar = GameObject.Find("Hbar").GetComponent<Image>();
            Hbar.fillAmount += 0.1f;

            Destroy(collision.collider.gameObject);
            if (gameobjectToFollow == null)
            {
                gameobjectToFollow = this.gameObject;
            }
            Instantiate(snakeFragmentPrefab, 
                gameobjectToFollow.transform.position- gameobjectToFollow.transform.forward*2, 
                gameobjectToFollow.transform.rotation);
        }
    }

    private void followObject() 
    {
        transform.LookAt(gameobjectToFollow.transform);

        float distance = Vector3.Distance(transform.position, gameobjectToFollow.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, gameobjectToFollow.transform.position, distance * 3 * Time.deltaTime);
    }
}
