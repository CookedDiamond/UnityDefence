using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int delay = 5;
    int ticks = 0;

    void FixedUpdate()
    {
        ticks++;
        if(ticks%delay == 0) Instantiate(prefab);

	}
}
