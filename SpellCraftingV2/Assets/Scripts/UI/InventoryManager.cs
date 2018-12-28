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
            if(inventorySlots[i].myItem == null)
            {
                //Add item
                inventorySlots[i].myItem = itemToAdd;
                inventorySlots[i].myImage.sprite = itemToAdd.inventoryIcon;
                inventorySlots[i].myImage.color = Color.white;


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


}
