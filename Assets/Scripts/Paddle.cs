using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float paddleMinUnits = 1f;
    [SerializeField] float paddleMaxUnits = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosUnits = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(Mathf.Clamp(mousePosUnits, paddleMinUnits, paddleMaxUnits), transform.position.y);
        transform.position = paddlePos;
    }
}
