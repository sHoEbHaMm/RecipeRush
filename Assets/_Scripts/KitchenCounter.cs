using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCounter : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject kitchenObject;
    [SerializeField] private Transform spawnPoint;
    public void Interact()
    {
        Transform objectTransform = Instantiate(kitchenObject.GetPrefab(), spawnPoint);
        objectTransform.localPosition = Vector3.zero;
        Debug.Log(objectTransform.GetComponent<KitchenObject>().GetObjectType().GetObjectName());
        //Debug.LogWarning("Interacting");
    }
}
