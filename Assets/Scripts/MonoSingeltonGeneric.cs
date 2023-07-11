using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingeltonGenric<T> : MonoBehaviour where T:MonoSingeltonGenric<T>
{
   
    private static T instance;

    public static T Instance{ get { return instance; } }

    protected virtual void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = (T)this;
        }
    }

}
