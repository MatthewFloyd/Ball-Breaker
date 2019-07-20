using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;

    [SerializeField] Vector2 paddleToBallVector;
    [SerializeField] Vector2 LaunchVector;
    //[SerializeField] float offsetX = 0f;
    //[SerializeField] float offsetY = 0.46f;


    private const string FireAxis = "Fire1";
    private bool _locked = true;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_locked)
        {
            LockBallToPaddle();
            if(Input.GetAxisRaw(FireAxis) != 0)
            {
                LaunchBall();
                _locked = false;
            }
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = (Vector2)paddle1.transform.position + paddleToBallVector;
    }

    private void LaunchBall()
    {
        GetComponent<Rigidbody2D>().velocity = LaunchVector;
    }
}
