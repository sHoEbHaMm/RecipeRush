using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private SO_KitchenObject kitchenObject;
    [SerializeField] private Transform spawnPoint;

    private KitchenObject objectOnTop;

    public void Interact(Player player)
    {

        if (objectOnTop == null)
        {
            Transform objectTransform = Instantiate(kitchenObject.GetPrefab(), spawnPoint);
            objectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            //Give object to the player
            objectOnTop.SetKitchenObjectParent(player);
        }
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
