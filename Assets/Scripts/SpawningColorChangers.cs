using System.Collections;
using UnityEngine;

public class SpawningColorChangers : MonoBehaviour
{

    public GameObject colorChangerPrefab;

    private GameObject player;
    private GameObject mainCamera;
    private float yPosition = 23.2f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        colorChangerPrefab = GameObject.FindWithTag("ColorChanger");
        mainCamera = GameObject.FindWithTag("MainCamera");
        gameObject.GetComponent<StopCoroutines>().all_Coroutines.Add(StartCoroutine(CircleChangerSpawner()));
    }

    void Update()
    {
        StopCor();
    }

    public void SpawnCircleChanger()
    {
        GameObject circleChanger = Instantiate(colorChangerPrefab);
        circleChanger.SetActive(true);
        circleChanger.transform.position = new Vector3(player.transform.position.x, yPosition, player.transform.position.z);
        yPosition += 15;
    }

    IEnumerator CircleChangerSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            SpawnCircleChanger();
        }
    }

    public void StopCor()
    {
        if (player.transform.position.y <= mainCamera.transform.position.y - 5 || !player.activeSelf)
        {
            gameObject.GetComponent<StopCoroutines>().StopRunningCoroutines();
        }
    }
}
