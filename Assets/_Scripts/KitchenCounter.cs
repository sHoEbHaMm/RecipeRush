using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCounter : BaseCounter
{
    [SerializeField] private SO_KitchenObject kitchenObject;

    public override void Interact(Player player)
    {
        if(!HasObjectOnTop())
        {
            if(player.HasObjectOnTop())
            {
                player.GetObjectOnTop().SetKitchenObjectParent(this);
            }

        }
        else
        {
            if(player.HasObjectOnTop())
            {

            }
            else
            {
                GetObjectOnTop().SetKitchenObjectParent(player);
            }
        }
    }

}
