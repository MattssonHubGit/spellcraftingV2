using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    [SerializeField] private InventorySlot[] inventorySlots = new InventorySlot[0];


    public void AddItem(Item itemToAdd, GameObject adder, bool destroyAdder)
    {
        //Check for free slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == null)
            {
                //Add item
                inventorySlots[i].myItem = itemToAdd;
                inventorySlots[i].myImage.sprite = itemToAdd.myItemData.inventoryIcon;
                inventorySlots[i].myImage.color = Color.white;
                itemToAdd.isInPlayerInventory = true;

                //Hide in world
                itemToAdd.GFXParent.gameObject.SetActive(false);
                itemToAdd.myCollider.enabled = false;


                //Destory adder?
                if (destroyAdder)
                {
                    GameObject.Destroy(adder);
                }
                //Exit
                return;
            }
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        //Check for the item
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == itemToRemove)
            {
                //Remove item
                inventorySlots[i].myItem = null;
                inventorySlots[i].myImage.color = new Color(1, 1, 1, 0);
                inventorySlots[i].myImage.sprite = itemToRemove.myItemData.inventoryIcon;
                itemToRemove.isInPlayerInventory = false;
                
                //Exit
                return;
            }
        }
    }

}
