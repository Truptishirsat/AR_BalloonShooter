using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // class for different pool objects
 [System.Serializable]
   
public class PoolItems<T>
{
    public T item;
    public bool is_ItemUsed;
}
public class ObjectPoolGeneric<T> : MonoSingeltonGenric<ObjectPoolGeneric<T>> where T: class
{
    // list for creating objectpool of poolitems
    List<PoolItems<T>> objectPool = new List<PoolItems<T>>();
    public int initialSize = 3;
    private void start()
    {
        while (initialSize > 0)
        {
            PoolItems<T> item = Createpoolitems();
            item.is_ItemUsed = false;
            initialSize --;
        }
    }
    
    // Pulling gameobject from objectpool
    public virtual T GetItem()
    {
        if(objectPool.Count > 0)
        {
            PoolItems<T> poolItems = objectPool.Find(i => i.is_ItemUsed == false);
            if(poolItems != null)
            {
                poolItems.is_ItemUsed = true;
                return poolItems.item;
            } 
            else
            {
                poolItems  = Createpoolitems();
                return poolItems.item;
            }
        }
        else
        {
            return Createpoolitems().item;
        }
    }

    // Returning gameobject to objectpool
    public virtual void ReturnToObjectPool(T item)
    {
        PoolItems<T> poolitems = objectPool.Find(i => i.item == item);
        poolitems.is_ItemUsed = false;
    }

    // Creating pooleditems and adding them to the objectpool
    PoolItems<T> Createpoolitems()
    {
        PoolItems<T> poolItems = new PoolItems<T>();
        poolItems.item = Createitem(this.gameObject);
        poolItems.is_ItemUsed = true;
        objectPool.Add(poolItems);

        return poolItems;
    }


    // item creation
    protected virtual T Createitem(GameObject parent)
    {
        return (T) null;
    }
    protected virtual void RemoveAllPooledItems()
    {
        for(int i=0; i<objectPool.Count; i++)
        {
            objectPool.Remove(objectPool[i]);
        }
    }

}
