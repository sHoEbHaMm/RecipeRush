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
        if(!player.HasObjectOnTop())
        {
            KitchenObject.SpawnKitchenObject(kitchenObject, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Player already holding something");
        }

    }

}
