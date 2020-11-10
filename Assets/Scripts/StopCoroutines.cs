using System.Collections.Generic;
using UnityEngine;

public  class StopCoroutines : MonoBehaviour
{

    public List<Coroutine> all_Coroutines;
    void Awake()
    {
        all_Coroutines = new List<Coroutine>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StopRunningCoroutines()
    {
        foreach (var cor in all_Coroutines)
        {
            StopCoroutine(cor);
        }
    }
}
