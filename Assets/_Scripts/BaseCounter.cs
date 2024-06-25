using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    private KitchenObject objectOnTop;
    [SerializeField] private Transform spawnPoint;

    public virtual void Interact(Player player)
    {

    }

    public Transform GetObjectSpawnPoint()
    {
        return this.spawnPoint;
    }

    public void SetObjectOnTop(KitchenObject newObjectOnTop)
    {
        objectOnTop = newObjectOnTop;
    }

    public KitchenObject GetObjectOnTop()
    {
        if (objectOnTop)
            return objectOnTop;
        return null;

    }

    public void ClearKitchenObject()
    {
        if (objectOnTop)
            objectOnTop = null;
    }

    public bool HasObjectOnTop()
    {
        return objectOnTop != null;

    }
}
