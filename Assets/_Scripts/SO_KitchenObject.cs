using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SO_KitchenObject : ScriptableObject
{
    [SerializeField] private Transform ObjectPrefab;
    [SerializeField] private Sprite Icon;
    [SerializeField] private string ObjectName;

    public Transform GetPrefab () {  return this.ObjectPrefab; }
    public Sprite GetIcon () { return this.Icon; }
    public string GetObjectName () { return this.ObjectName;}

}
