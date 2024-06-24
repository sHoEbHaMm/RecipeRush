using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject objectType;
    private KitchenCounter parentCounter;

    public SO_KitchenObject GetObjectType() { return objectType; }

    public KitchenCounter GetCounter() { return this.parentCounter; }

    public void SetCounter(KitchenCounter newCounter) {

        if (newCounter.HasObjectOnTop())
        {
            Debug.LogError("Counter already has an object on top of it!");
            return;
        }

        if (this.parentCounter != null)
        {
            this.parentCounter.ClearKitchenObject();
        }

        this.parentCounter = newCounter;

        newCounter.SetObjectOnTop(this);
        transform.parent = this.parentCounter.GetObjectSpawnPoint();
        transform.localPosition = Vector3.zero;

    }
}
