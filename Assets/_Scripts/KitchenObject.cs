using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject objectType;
    private IKitchenObjectParent kitchenObjectParent;

    public SO_KitchenObject GetObjectType() { return objectType; }

    public IKitchenObjectParent GetKitchenObjectParent() { return this.kitchenObjectParent; }

    public void SetKitchenObjectParent(IKitchenObjectParent newParent) 
    {
        if(newParent != null)
        {
            if(newParent.HasObjectOnTop())
            {
                Debug.LogError("The other counter is already occupied");
            }
            else
            {

                if(kitchenObjectParent != null)
                {
                    this.kitchenObjectParent.ClearKitchenObject();
                }

                this.kitchenObjectParent = newParent;
                transform.parent = newParent.GetObjectSpawnPoint();
                transform.localPosition = Vector3.zero;
                newParent.SetObjectOnTop(this);
            }
        }
    

    }
}
