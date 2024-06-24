using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject objectType;
    private KitchenCounter parentCounter;

    public SO_KitchenObject GetObjectType() { return objectType; }

    public KitchenCounter GetCounter() { return this.parentCounter; }

    public void SetCounter(KitchenCounter newCounter) 
    {
        if(newCounter)
        {
            if(newCounter.HasObjectOnTop())
            {
                Debug.LogError("The other counter is already occupied");
            }
            else
            {
                if(parentCounter)
                {
                    this.parentCounter.ClearKitchenObject();
                }

                this.parentCounter = newCounter;
                transform.parent = newCounter.GetObjectSpawnPoint();
                transform.localPosition = Vector3.zero;
                newCounter.SetObjectOnTop(this);
            }
        }
    

    }
}
