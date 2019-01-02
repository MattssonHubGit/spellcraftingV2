using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    //TODO: Implement animation and PickUp

    [Header("Item")]
    [SerializeField] public string itemName = "";
    [SerializeField] protected int itemID;
    [SerializeField] protected bool bagable = true;
    [Space]
    [SerializeField] public Sprite inventoryIcon;
    [SerializeField] public Mesh worldMesh;
    [SerializeField] public Material worldMaterial;
    

    public virtual void InWorldAnimation(GameObject objectToAnimate){}
    protected virtual void PickUp(){}
    public virtual void UseItem()
    {
        Debug.Log("No override of virtual UseItem() for " + itemName + "implemented");
    }
    public virtual void UseItem(Item item)
    {
        Debug.Log("No override of virtual UseItem(GameObject item) for " + itemName + "implemented");
    }

}
