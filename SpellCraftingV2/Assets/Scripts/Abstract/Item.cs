using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] protected string itemName = "";
    [SerializeField] protected int itemID;
    [SerializeField] protected bool bagable = true;
    [Space]
    [SerializeField] protected Sprite inventoryIcon;
    [SerializeField] protected Mesh worldMesh;
    [SerializeField] protected Material worldMaterial;

    protected void InWorldAnimation(){}
    protected void PickUp(){}
    protected abstract void UseItem();

}
