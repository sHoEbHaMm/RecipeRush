using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject objectType;

    public SO_KitchenObject GetObjectType() { return objectType; }
}
