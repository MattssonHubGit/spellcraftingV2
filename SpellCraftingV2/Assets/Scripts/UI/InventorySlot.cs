using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Item myItem;
    public Image myImage;


    //Should be called via button
    public void UseMyItem()
    {
        //Only use if item is available
        if (myItem != null)
        {
            myItem.UseItem();
        }
    }
}
