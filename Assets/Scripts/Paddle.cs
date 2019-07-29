using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float paddleMinUnits = 1f;
    [SerializeField] float paddleMaxUnits = 15f;

    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), paddleMinUnits, paddleMaxUnits), transform.position.y);
        transform.position = paddlePos;
    }
    
    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
            return ball.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * screenWidthUnits; // mouse position
    }
}
