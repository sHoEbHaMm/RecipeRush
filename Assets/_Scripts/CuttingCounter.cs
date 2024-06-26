using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private SO_CuttingRecipe[] cuttingRecipes;
    public override void Interact(Player player)
    {
        if (!HasObjectOnTop()) //If empty
        {
            if (player.HasObjectOnTop()) //And player has something in hand
            {
                player.GetObjectOnTop().SetKitchenObjectParent(this); //place it on the counter
            }

        }
        else //if not empty
        {
            if (player.HasObjectOnTop()) //And player has something in hand, do nothing
            {

            }
            else
            {
                //Give it back to the player+
                GetObjectOnTop().SetKitchenObjectParent(player);
            }
        }
    }

    public override void AltInteract(Player player)
    {
        if(HasObjectOnTop())
        {
            SO_KitchenObject slicedObject = GetSlicedObject(GetObjectOnTop().GetObjectType());

            if (slicedObject)
            {
                GetObjectOnTop().DestroySelf();
                KitchenObject.SpawnKitchenObject(slicedObject, this);
            }
            else
            {
                Debug.Log("Counter empty, nothing to slice!");
            }


        }
    }

    private SO_KitchenObject GetSlicedObject(SO_KitchenObject in_KitchenObject)
    {
        SO_KitchenObject o_KitchenObject = null;

        foreach (SO_CuttingRecipe sO_CuttingRecipe in cuttingRecipes)
        {
            if(sO_CuttingRecipe.GetInObject() == in_KitchenObject)
            {
                o_KitchenObject = sO_CuttingRecipe.GetOutObject();
            }
        }

        return o_KitchenObject;
    }
}
