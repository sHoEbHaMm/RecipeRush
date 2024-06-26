using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(SO_KitchenObject sO_KitchenObject, IKitchenObjectParent parent)
    {
        Transform objectTransform = Instantiate(sO_KitchenObject.GetPrefab());

        KitchenObject kitchenObject = objectTransform.GetComponent<KitchenObject>();

        kitchenObject.SetKitchenObjectParent(parent);
        
        return kitchenObject;
    }
}
