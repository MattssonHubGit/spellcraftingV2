using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    //TODO: Implement animation and PickUp

    [Header("Item")]
    [SerializeField] protected string itemName = "";
    [SerializeField] protected int itemID;
    [SerializeField] protected bool bagable = true;
    [Space]
    [SerializeField] protected Sprite inventoryIcon;
    [SerializeField] protected Mesh worldMesh;
    [SerializeField] protected Material worldMaterial;

    protected virtual void InWorldAnimation(){}
    protected virtual void PickUp(){}
    public abstract void UseItem();

}
