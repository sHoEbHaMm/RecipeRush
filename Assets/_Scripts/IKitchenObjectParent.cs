using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetObjectSpawnPoint();

    public void SetObjectOnTop(KitchenObject newObjectOnTop);

    public KitchenObject GetObjectOnTop();

    public void ClearKitchenObject();

    public bool HasObjectOnTop();
}
