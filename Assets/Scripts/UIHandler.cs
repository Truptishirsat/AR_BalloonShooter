using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
   public GameObject arCamera;
   public float destroyDelay = 3f;
  
   
   public void shoot()
   {
        RaycastHit hit;

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            
            if(hit.transform.name == "Balloon_Ghost Yellow(Clone)" || hit.transform.name == "Balloon_Ghost(Clone)" || hit.transform.name == "Balloon_Ghost_LightBrown(Clone)")
            {
                ParticleSystemController particleSystemController = ParticleSystemObjectPool.Instance.GetItem();
                particleSystemController.gameObject.transform.position = hit.point;

                BalloonController controller = hit.transform.GetComponent<BalloonController>();
                controller.gameObject.SetActive(false);
                BalloonObjectPool.Instance.ReturnToObjectPool(controller);

                particleSystemController.gameObject.SetActive(true);
                particleSystemController.gameObject.transform.rotation = Quaternion.identity;
                
                StartCoroutine(DestroyParticleSystem(particleSystemController));
            }
        }
        
   }

   IEnumerator DestroyParticleSystem(ParticleSystemController controller)
   {
        yield return new WaitForSeconds(1f);
        ParticleSystemObjectPool.Instance.ReturnToObjectPool(controller);
        controller.gameObject.SetActive(false);
   }

}
