using UnityEngine;

public class DestroyCircle : MonoBehaviour
{
    private GameObject player;
    private float yPosition = 20f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        DespawnCircle();
    }

    public void DespawnCircle()
    {
        if (transform.position.y < player.transform.position.y - 10 && transform.position.y > yPosition)
        {
            Destroy(gameObject);
        }
    }
}
