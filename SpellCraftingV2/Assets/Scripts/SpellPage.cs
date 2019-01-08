using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpellPage : ItemData {

    //TODO: Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference
    //Add interaction with SpellBook

    [Header("Runes")]
    [SerializeField] private RiteRune rite;
    [SerializeField] private CoreRune core;
    [SerializeField] private MethodRune method;



    #region Getters
    public RiteRune Rite
    {
        get
        {
            return rite;
        }

        set
        {
            rite = value;
        }
    }
    public CoreRune Core
    {
        get
        {
            return core;
        }

        set
        {
            core = value;
        }
    }
    public MethodRune Method
    {
        get
        {
            return method;
        }

        set
        {
            method = value;
        }
    }
    #endregion


    public void CastSpell(LivingEntity _caster, InWorldPage _page)
    {
        rite.InciteSpell(_caster, _page);
    }

    public override void UseItem(Item item)
    {
        PageCrafting cachePage = CraftingPanels.Instance.page;

        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            Debug.Log("New spell equipped!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpellBook>().Spell = item as InWorldPage;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cachePage.pageOutputSlot.myItem == item)
                {
                    cachePage.pageOutputSlot.myItem = null;
                    cachePage.pageOutputSlot.myImage.color = new Color(1, 1, 1, 0);
                    cachePage.pageOutputSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }

}
