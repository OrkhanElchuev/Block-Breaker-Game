using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Configuration parameters 
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] GameStatus gameStatus;

    // Cached components
    Rigidbody2D myRigidBody2D;

    // Variables
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    private float maxSpeedOfBall = 18.0f;
    private float minSpeedOfBall = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // avoiding too fast and too slow speed of the ball
        if (myRigidBody2D.velocity.magnitude > maxSpeedOfBall ||
            myRigidBody2D.velocity.magnitude < minSpeedOfBall)
        {
            myRigidBody2D.velocity = Vector2.ClampMagnitude(myRigidBody2D.velocity, maxSpeedOfBall);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    // Launch the ball on mouseclick(or tap)
    private void LaunchOnMouseClick()
    {
        // 0 represents left button of mouse
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    // Locking balls position to the paddle
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    // Handling processes after ball's collision with objects
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        // Adding random factor for avoiding ball looping between two objects
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        // If ball collides with Lose Collider area
        if(collision.gameObject.name == "Lose Collider")
        {
            DestroyMyself();

            // Create a new ball and enable all of its components
            Ball newBall = Instantiate(this);
            newBall.GetComponent<Ball>().enabled = true;
            newBall.GetComponent<AudioSource>().enabled = true;
            newBall.GetComponent<CircleCollider2D>().enabled = true;

            // Identify current position of paddle
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            
            // Attach newly created ball to paddle
            newBall.transform.position = paddlePos + paddleToBallVector;
        }

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    // Method for destroying Ball object and handling Game Over scene after loosing all trials
    public void DestroyMyself()
    {
        if(gameStatus.DecreaseHealth() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        Destroy(gameObject);
    } 
}
