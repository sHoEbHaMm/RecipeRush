using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private SO_KitchenObject kitchenObject;

    public override void Interact(Player player)
    {

        if (!HasObjectOnTop())
        {
            Transform objectTransform = Instantiate(kitchenObject.GetPrefab());
            objectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
