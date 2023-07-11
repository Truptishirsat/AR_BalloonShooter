using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObjectPool : ObjectPoolGeneric<ParticleSystemController>   
{
    [SerializeField] private ParticleSystem particlesystem;

    protected override ParticleSystemController Createitem(GameObject parent)
    {
        ParticleSystem spawnedParticleSystem = Instantiate(particlesystem);
        spawnedParticleSystem.transform.SetParent(parent.transform);
        ParticleSystemController controller =  spawnedParticleSystem.GetComponent<ParticleSystemController>();
        return controller;
    }
}
