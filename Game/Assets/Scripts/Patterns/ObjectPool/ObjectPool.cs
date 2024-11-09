using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : IObjectPool
{

    IPooleableObject prefab;
    List<IPooleableObject> objects;
    private int initialNumber;
    private bool allowNew;
    private int activeObjects;
    private float maxElem;

    public ObjectPool(IPooleableObject prefab_, int initialNumber_, bool allowNew_, float maxElem_)
    {
        prefab = prefab_;
        initialNumber = initialNumber_;
        allowNew = allowNew_;
        maxElem = maxElem_;

        objects = new List<IPooleableObject>(initialNumber);
        activeObjects = 0;
        GameObject poolObject = new GameObject();

        for (int i = 0; i < initialNumber_; i++)
        {
            objects.Add(CreateObject());
        }
    }

    public IPooleableObject Get()
    {
        for (int i = 0;i < objects.Count; i++)
        {
            if (!objects[i].Active)
            {
                activeObjects++;
                objects[i].Active = true;
                return objects[i];
            }
        }

        if (allowNew)
        {
            IPooleableObject obj = CreateObject();
            obj.Active = true;
            obj.SetPool(this);
            objects.Add(obj);
            activeObjects++;
            return obj;
        }

        return null;
    }

    public void Release(IPooleableObject obj)
    {
        activeObjects--;
        obj.Active = false;
        obj.Reset();

        if (objects.Count > maxElem)
        {
            objects.Remove(obj);
            obj.Destroy();
        }
    }

    public IPooleableObject CreateObject()
    {
        IPooleableObject obj = prefab.Clone();
        obj.Active = false;
        obj.SetPool(this);
        return obj;
    }

}
