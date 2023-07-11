using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] Spawnpoints;

    void Start()
    {
        StartCoroutine(StartSpawningBalloon());
    }

    IEnumerator StartSpawningBalloon()
    {
        yield return new WaitForSeconds(3);

        for(int i = 0; i < 3; i++)
        {
            BalloonController controller = BalloonObjectPool.Instance.GetItem();
            controller.gameObject.SetActive(true);
            controller.transform.position = Spawnpoints[i].position;
            controller.transform.rotation = Quaternion.identity;
            controller.SetSpawnTimePoint(Time.time);

            StartCoroutine(DestroyBallon(controller, controller.GetSpawnTimePoint()));
        }

        StartCoroutine(StartSpawningBalloon());
    }

    IEnumerator DestroyBallon(BalloonController controller, float timePoint)
    {
        yield return new WaitForSeconds(12f);
        
        if(controller.GetSpawnTimePoint() == timePoint)
        {
            BalloonObjectPool.Instance.ReturnToObjectPool(controller);
            controller.gameObject.SetActive(false);
        }
    }
}
