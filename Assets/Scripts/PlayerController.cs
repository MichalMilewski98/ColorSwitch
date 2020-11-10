using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 10f;
    public float restartDelay = 1f;
    public string currentColor;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public GameObject mainCamera;
    public Canvas endGameCanvas;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    private StopCoroutines coroutines;
    private int index;
    private bool gameHasEnded = false;


    void Start()
    {
        coroutines = gameObject.AddComponent<StopCoroutines>();
        SetRandomColor();
    }

    void Update()
    {
        if(CheckVerticalScreenBounds())
            SetEndGameCanvas();
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("PauseMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger" && collision.transform.position.y < 9)
        {
            SetRandomColor();
            collision.gameObject.SetActive(false);
            return;
        }

        if (collision.tag == "ColorChanger" && collision.transform.position.y > 9)
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != currentColor)
        {
            SetEndGameCanvas();
        }
    }

    public void SetRandomColor()
    {
        int check = index;
        do
        {
            check = index;
            index = Random.Range(0, 4);
        } while (check == index);

        switch (index)
        {
            case 0:
            {
                currentColor = "Cyan";
                spriteRenderer.color = colorCyan;
                break;
            }
            case 1:
            {
                currentColor = "Yellow";
                spriteRenderer.color = colorYellow;
                break;
            }
            case 2:
            {
                currentColor = "Magenta";
                spriteRenderer.color = colorMagenta;
                break;
            }
            case 3:
            {
                currentColor = "Pink";
                spriteRenderer.color = colorPink;
                break;
            }
        }
    }

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            Invoke("RestartGame", restartDelay);
            gameHasEnded = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetEndGameCanvas()
    {
        endGameCanvas.gameObject.SetActive(true);
    }

    public bool CheckVerticalScreenBounds()
    {
        if (transform.position.y <= mainCamera.transform.position.y - 5)
            return true;
        return false;
    }
}
