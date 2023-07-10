using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public Transform[] Spawnpoints;
    public GameObject[] Balloons;

    void Start()
    {
        StartCoroutine(StartSpawningBalloon());
        
    }

    IEnumerator StartSpawningBalloon()
    {
        yield return new WaitForSeconds(4);
        for(int i = 0; i < 3; i++)
        {
            Instantiate(Balloons[i], Spawnpoints[i].position, Quaternion.identity);
        }
        StartCoroutine(StartSpawningBalloon());
        

    }
}
