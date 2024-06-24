using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCounter : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject kitchenObject;
    [SerializeField] private Transform spawnPoint;

    private KitchenObject objectOnTop;

    //Testing
    [SerializeField] private KitchenCounter otherCounter;

    private void Start()
    {
        Debug.Log(objectOnTop);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && objectOnTop != null)
        {
            objectOnTop.SetCounter(otherCounter);
        }
    }
    public void Interact()
    {
        if(objectOnTop == null)
        {
            Transform objectTransform = Instantiate(kitchenObject.GetPrefab(), spawnPoint); 
            objectTransform.GetComponent<KitchenObject>().SetCounter(this);
        }
        else

        {
            Debug.Log(objectOnTop.GetCounter());
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
        if(objectOnTop)
            return objectOnTop;
        return null;
    }

    public void ClearKitchenObject()
    {
        if(objectOnTop)
            objectOnTop = null; 
    }

    public bool HasObjectOnTop()
    {
        return objectOnTop != null;

    }
}
