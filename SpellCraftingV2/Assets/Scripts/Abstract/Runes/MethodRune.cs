using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MethodRune : Rune
{
    //TODO: Implement UseItem to add item into craftingUI

    [Header("Method Rune")]
    [SerializeField] private BehaviourAspect behaviour;
    [SerializeField] private List<BehaviourModAspect> modifiers = new List<BehaviourModAspect>();



    #region GetSetters
    public BehaviourAspect Behaviour
    {
        get
        {
            return behaviour;
        }
        set
        {
            behaviour = value;
        }
    }

    public List<BehaviourModAspect> Modifiers
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
                if (cachePage.methodSlot.myItem == null)
                {
                    cachePage.methodSlot.myItem = item;
                    cachePage.methodSlot.myImage.sprite = inventoryIcon;
                    cachePage.methodSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cachePage.methodSlot.myItem == item)
                {
                    cachePage.methodSlot.myItem = null;
                    cachePage.methodSlot.myImage.color = new Color(1, 1, 1, 0);
                    cachePage.methodSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
                MethodCrafting cacheMethod = CraftingPanels.Instance.method;
                if (cacheMethod.runeOutputSlot.myItem == item)
                {
                    cacheMethod.runeOutputSlot.myItem = null;
                    cacheMethod.runeOutputSlot.myImage.color = new Color(1, 1, 1, 0);
                    cacheMethod.runeOutputSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }


}
