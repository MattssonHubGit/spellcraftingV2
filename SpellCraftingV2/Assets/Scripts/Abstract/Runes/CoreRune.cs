using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CoreRune : Rune {

    //TODO: Implement UseItem to add item into craftingUI

    [Header("Core Rune")]
    [SerializeField] private ObjectAspect spellObject;
    [SerializeField] private List<CoreModAspect> modifiers = new List<CoreModAspect>();

    #region GetSetters
    public ObjectAspect SpellObject
    {
        get
        {
            return spellObject;
        }
        set
        {
            spellObject = value;
        }
    }

    public List<CoreModAspect> Modifiers
    {
        get
        {
            return modifiers;
        }
        set
        {
            modifiers = value;
        }
    }
    #endregion

    public override void UseItem(Item item)
    {
        PageCrafting cachePage = CraftingPanels.Instance.page;
     
        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cachePage.coreSlot.myItem == null)
                {
                    cachePage.coreSlot.myItem = item;
                    cachePage.coreSlot.myImage.sprite = inventoryIcon;
                    cachePage.coreSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cachePage.coreSlot.myItem == item)
                {
                    cachePage.coreSlot.myItem = null;
                    cachePage.coreSlot.myImage.color = new Color(1, 1, 1, 0);
                    cachePage.coreSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }

                CoreCrafting cacheCore = CraftingPanels.Instance.core;
                if (cacheCore.runeOutputSlot.myItem == item)
                {
                    cacheCore.runeOutputSlot.myItem = null;
                    cacheCore.runeOutputSlot.myImage.color = new Color(1, 1, 1, 0);
                    cacheCore.runeOutputSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }
        }
    }
}
