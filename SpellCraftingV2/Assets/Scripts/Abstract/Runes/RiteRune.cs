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
        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (CraftingPanels.Instance.page.riteSlot.myItem == null)
                {
                    CraftingPanels.Instance.page.riteSlot.myItem = item;
                    CraftingPanels.Instance.page.riteSlot.myImage.sprite = inventoryIcon;
                    CraftingPanels.Instance.page.riteSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (CraftingPanels.Instance.page.riteSlot.myItem == item)
                {
                    CraftingPanels.Instance.page.riteSlot.myItem = null;
                    CraftingPanels.Instance.page.riteSlot.myImage.color = new Color(1, 1, 1, 0);
                    CraftingPanels.Instance.page.riteSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }

    }
}
