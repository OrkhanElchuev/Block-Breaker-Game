using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Config parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] GameStatus gameStatus;

    // Cached component
    Rigidbody2D myRigidBody2D;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
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

    private void LaunchOnMouseClick()
    {
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
