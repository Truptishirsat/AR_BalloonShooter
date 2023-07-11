using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    private float spawnTimePoint;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 0.55f);
    }

    public void SetSpawnTimePoint(float time)
    {
        spawnTimePoint = time;
    }

    public float GetSpawnTimePoint()
    {
        return spawnTimePoint;
    }
}
