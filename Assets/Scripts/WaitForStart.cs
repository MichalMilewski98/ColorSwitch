using UnityEngine;

public class WaitForStart : MonoBehaviour
{
    private float gravityScale = 3f;
    private bool isGameStarted = false;
   
    void Start()
    {
        SetGravityScale(0);
    }

    void Update()
    {
        if (!isGameStarted)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            SetGravityScale(gravityScale);
            isGameStarted = true;
        }
    }

    private void SetGravityScale(float gravity)
    {
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
}
