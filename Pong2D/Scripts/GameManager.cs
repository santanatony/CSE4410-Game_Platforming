using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public int p1Score;
    public int p2Score;
    public Text scoreText;
    public int scoreToWin;
    public Text winner;
    public GameObject p1Win;
    public GameObject p2Win;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    void Start()
    {
        // Convert screen's pixel coordinate into game's position
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2 (0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));

        // Create ball
        Instantiate (ball);

        // Create two paddles
        Paddle paddle1 = Instantiate (paddle) as Paddle;
        Paddle paddle2 = Instantiate (paddle) as Paddle;
        paddle1.Init (true); // right paddle
        paddle2.Init (false); // left paddle

    }

    public void Score(bool p1)
    {
        if (p1)
        {
            p1Score++;
            // Player 1 wins
            if (p1Score >= scoreToWin)
            {
                p1Win.gameObject.SetActive(true);
                Debug.Log("Player 1 wins!");
                Time.timeScale = 0;
                enabled = false;
            }
        }
        else
        {
            p2Score++;
            // Player 2 wins
            if (p2Score >= scoreToWin)
            {
                p2Win.gameObject.SetActive(true);
                Debug.Log("Player 2 wins!");
                Time.timeScale = 0;
                enabled = false;
            }
        }

        scoreText.text = p1Score.ToString() + " : " + p2Score.ToString();
    }

    
}
