using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle) {

        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle) {
            // Place paddle on right of screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // Move a bit to the left

            input = "PaddleRight";

        } else {
            // Place paddle on left of screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; // Move a bit to the right

            input = "PaddleLeft";
        }

        // update paddle's position
        transform.position = pos;

        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // Restrict Paddle movement
        // Stops paddle from moving too far up/down
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
