using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
   public GameObject arCamera;
   public ParticleSystem particlesystem;
   private ParticleSystem spawnedParticleSystem;
   public float destroyDelay = 3f;
  
   
   public void shoot()
   {
        RaycastHit hit;

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            
            if(hit.transform.name == "Balloon_Ghost Yellow(Clone)" || hit.transform.name == "Balloon_Ghost(Clone)" || hit.transform.name == "Balloon_Ghost_LightBrown(Clone)")
            {
                spawnedParticleSystem = Instantiate(particlesystem,hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(spawnedParticleSystem.gameObject, destroyDelay);
                Destroy(hit.transform.gameObject);
            }
        }
        
   }

}
