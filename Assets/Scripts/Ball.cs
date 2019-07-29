using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] Vector2 LaunchVector;
    [SerializeField] float RandomFactor = 0.2f;

    Vector2 paddleToBallVector;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    private const string FireAxis = "Fire1";
    private bool _locked = true;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
        myRigidBody2D.velocity = LaunchVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityRand = new Vector2(Random.Range(0f, RandomFactor), // (Random.Range(0, 2) * 2 - 1) sets positive or negative randomly
                                            Random.Range(0f, RandomFactor)); // preventing ball sticks on only x or only y axis

        if(_locked) { return;  }
        myAudioSource.PlayOneShot(ballSounds[UnityEngine.Random.Range(0, ballSounds.Length-1)]);
        myRigidBody2D.velocity += velocityRand;
    }
}
