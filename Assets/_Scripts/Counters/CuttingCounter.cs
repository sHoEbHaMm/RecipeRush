using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

    public event EventHandler OnCutPerformed;

    [SerializeField] private SO_CuttingRecipe[] cuttingRecipes;
    private int numberOfCuts;
    public override void Interact(Player player)
    {
        if (!HasObjectOnTop()) //If empty
        {
            if (player.HasObjectOnTop()) //And player has something in hand
            {
                if(ifRecipeExistsForObject(player.GetObjectOnTop().GetObjectType()))
                {
                    player.GetObjectOnTop().SetKitchenObjectParent(this); //place it on the counter
                    numberOfCuts = 0;

                    SO_CuttingRecipe sO_CuttingRecipe = GetRecipeSO(GetObjectOnTop().GetObjectType());

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = (float) numberOfCuts / sO_CuttingRecipe.getCutsRequiredToSlice()
                    }) ;
                }
                else
                {
                    Debug.Log("Cannot slice this item");
                }
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
            numberOfCuts++;

            OnCutPerformed?.Invoke(this, EventArgs.Empty);

            SO_CuttingRecipe o_CuttingRecipe = GetRecipeSO(GetObjectOnTop().GetObjectType());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                progressNormalized = (float)numberOfCuts / o_CuttingRecipe.getCutsRequiredToSlice()
            });

            if (numberOfCuts == o_CuttingRecipe.getCutsRequiredToSlice())
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
    }

    private SO_KitchenObject GetSlicedObject(SO_KitchenObject in_KitchenObject)
    {
        SO_CuttingRecipe o_CuttingRecipe = GetRecipeSO(in_KitchenObject); 

        if(o_CuttingRecipe)
        {
            return o_CuttingRecipe.GetOutObject();
        }
        return null;
 
    }

    private bool ifRecipeExistsForObject(SO_KitchenObject i_Object)
    {
        SO_CuttingRecipe o_CuttingRecipe = GetRecipeSO(i_Object);

        return o_CuttingRecipe != null;
    }

    private SO_CuttingRecipe GetRecipeSO(SO_KitchenObject i_Object)
    {
        foreach (SO_CuttingRecipe sO_CuttingRecipe in cuttingRecipes)
        {
            if (sO_CuttingRecipe.GetInObject() == i_Object)
            {
                return sO_CuttingRecipe;
            }
        }
        return null;
    }
}
