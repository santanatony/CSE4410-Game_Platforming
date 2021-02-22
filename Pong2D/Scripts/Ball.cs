using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    GameManager cont;

    void Start()
    {
        cont = FindObjectOfType<GameManager>();
        
        direction = Vector2.one.normalized; // direction is (1,1)
        radius = transform.localScale.x / 2; // half the width
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Bounce off bottom/top
        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if(transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
    
        // Points
        // Player 1 scores
        if(transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            transform.position = new Vector3(0, 0, 0);
            cont.Score(false);
        }
        // Player 2 scores
        if(transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            transform.position = new Vector3(0, 0, 0);
            cont.Score(true);

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle> ().isRight;

            // if hitting right paddle and moving right, flip ball direction
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            // if hitting left paddle and moving left, flip ball direction
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
    
}
