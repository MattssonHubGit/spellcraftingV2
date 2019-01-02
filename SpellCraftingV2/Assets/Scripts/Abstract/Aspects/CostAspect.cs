using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CostAspect : Aspect
{
    //TODO:  Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference


    [Header("Cost Aspect")]
    [SerializeField] protected LivingEntity.ResourceType costType;
    [SerializeField] protected int costAmount;


    [HideInInspector] public RiteRune Rune;

    /// <summary>
    /// Return true and deduct pay from user if possible, otherwise return false.
    /// </summary>
    /// <param name="caster"></param>
    /// <returns></returns>
    public abstract bool AttemptPay(LivingEntity caster);


    public override void UseItem(Item item)
    {
        RiteCrafting cache = CraftingPanels.Instance.rite;

        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cache.costSlot.myItem == null)
                {
                    cache.costSlot.myItem = item;
                    cache.costSlot.myImage.sprite = inventoryIcon;
                    cache.costSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cache.costSlot.myItem == item)
                {
                    cache.costSlot.myItem = null;
                    cache.costSlot.myImage.color = new Color(1, 1, 1, 0);
                    cache.costSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }

}
