using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SO_CuttingRecipe : ScriptableObject
{
    [SerializeField] private SO_KitchenObject in_Object;
    [SerializeField] private SO_KitchenObject out_Object;
    [SerializeField] private int cutsRequiredToSlice;

    public SO_KitchenObject GetInObject() { return in_Object; }
    public SO_KitchenObject GetOutObject() { return out_Object; }
    public int getCutsRequiredToSlice() {  return cutsRequiredToSlice; }

}
