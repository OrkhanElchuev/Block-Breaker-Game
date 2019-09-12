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
    private float maxSpeedOfBall = 15.0f;
    private float minSpeedOfBall = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
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

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if(collision.gameObject.name == "Lose Collider")
        {
            Debug.Log("I destroyed");
            DestroyMyself();
            Ball newBall = Instantiate(this);
            newBall.GetComponent<Ball>().enabled = true;
            newBall.GetComponent<AudioSource>().enabled = true;
            newBall.GetComponent<CircleCollider2D>().enabled = true;
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            //paddleToBallVector = newBall.transform.position - paddle.transform.position;
            newBall.transform.position = paddlePos + paddleToBallVector;
        }

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void DestroyMyself()
    {
        if(gameStatus.DecreaseHealth() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        Destroy(gameObject);
    } 
}
