using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonObjectPool : ObjectPoolGeneric<BalloonController>
{
    public GameObject[] Balloons;
    int i = 0;

    protected override BalloonController Createitem(GameObject parent)
    {
        if(i >= 3)
        {
            i = 0;
        }

        GameObject balloon = Instantiate(Balloons[i]);
        balloon.transform.SetParent(parent.transform);
        balloon.SetActive(false);

        BalloonController controller = balloon.GetComponent<BalloonController>();

        i++;
        return controller;
    }
}
