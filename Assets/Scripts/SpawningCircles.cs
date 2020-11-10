using System.Collections;
using UnityEngine;

public class SpawningCircles : MonoBehaviour
{

    public GameObject circlePrefab;
    
    private float yPosition = 27.2f;
    private float respawnTime = 3f;
    private GameObject player;
    private StopCoroutines stopCoroutines;

    void Awake()
    {
        stopCoroutines = gameObject.AddComponent<StopCoroutines>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        circlePrefab = GameObject.FindWithTag("SmallCircle");
        stopCoroutines.all_Coroutines.Add(StartCoroutine(CircleSpawner()));
    }

    void Update()
    {
        
    }

    private void SpawnCircle()
    {
        GameObject circle = Instantiate(circlePrefab);
        circle.transform.position = new Vector3(transform.position.x, yPosition, player.transform.position.z);
        yPosition += 8;
    }

    IEnumerator CircleSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnCircle();
        }
       
    }
}
