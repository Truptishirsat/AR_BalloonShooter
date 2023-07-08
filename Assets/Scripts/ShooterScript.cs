using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
   public GameObject arCamera;
   public GameObject smoke;

   public void shoot()
   {
        RaycastHit hit;

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if(hit.transform.name == "Balloon_Ghost Yellow(Clone)" || hit.transform.name == "Balloon_Ghost(Clone)" || hit.transform.name == "Balloon_Ghost_LightBrown(Clone)")
            {
                Destroy(hit.transform.gameObject);
            }

            Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
        }
   }
}
