using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RiteRune : Rune
{

    //TODO: Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference

    [Header("Rite Rune")]
    [SerializeField]
    private ActivasionAspect activasion;
    [SerializeField] private CostAspect cost;



    #region GetSetters
    public ActivasionAspect Activasion
    {
        get
        {
            return activasion;
        }
        set
        {
            activasion = value;
        }
    }

    public CostAspect Cost
    {
        get
        {
            return cost;
        }
        set
        {
            cost = value;
        }
    }


    #endregion


    /// <summary>
    /// Starts casting the spell by using the Aim() of it's ActivasionAspect
    /// </summary>
    /// <param name="caster"></param>
    public void InciteSpell()
    {
        //Debug.Log("MethodRune InciteSpell() not implemented yet");
        Caster.CastState = LivingEntity.CasterState.AIMING;

        activasion.Aim(cost);
    }

    public override void UseItem(Item item)
    {
        PageCrafting cachePage = CraftingPanels.Instance.page;

        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cachePage.riteSlot.myItem == null)
                {
                    cachePage.riteSlot.myItem = item;
                    cachePage.riteSlot.myImage.sprite = inventoryIcon;
                    cachePage.riteSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cachePage.riteSlot.myItem == item)
                {
                    cachePage.riteSlot.myItem = null;
                    cachePage.riteSlot.myImage.color = new Color(1, 1, 1, 0);
                    cachePage.riteSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }

                RiteCrafting cacheRite = CraftingPanels.Instance.rite;
                if (cacheRite.runeOutputSlot.myItem == item)
                {
                    cacheRite.runeOutputSlot.myItem = null;
                    cacheRite.runeOutputSlot.myImage.color = new Color(1, 1, 1, 0);
                    cacheRite.runeOutputSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }
}
