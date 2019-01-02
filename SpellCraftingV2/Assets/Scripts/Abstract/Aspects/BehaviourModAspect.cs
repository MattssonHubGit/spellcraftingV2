using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourModAspect : Aspect
{

    //TODO:  Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference

    [Header("Behaviour Mod Aspect")]
    [SerializeField] protected BehaviourAspect.BehaviourType modForType;
    [SerializeField] protected bool shouldApplyScript;
    [SerializeField] protected bool shouldChangeVariables;
    [SerializeField] protected string behaviourScript = "";


    [HideInInspector] public MethodRune Rune;

    #region GetSetters
    public bool ShouldApplyScript
    {
        get
        {
            return shouldApplyScript;
        }
    }
    public bool ShouldChangeVariables
    {
        get
        {
            return shouldChangeVariables;
        }
    }
    public BehaviourAspect.BehaviourType ModForType
    {
        get
        {
            return modForType;
        }
    }
    #endregion

    public virtual void SetModBehaviourAndData(GameObject applyTo)
    {
        //Check if the script exists, and is a Behaviour. If so, add it and if not debug errors
        System.Type mType = System.Type.GetType(behaviourScript);
        if (mType == null) //Does the string translate to the name of a class?
        {
            Debug.LogError("BehaviourScript string does not match any existing script name");
        }
        else
        {
            if (mType.GetType().IsInstanceOfType(typeof(LesserBehaviour))) //Is the class deriving from Behaviour?
            {
                //Add the class and set it's latest added LesserBehaviour data to a subclass of BehaviourModAspect
                LesserBehaviour thisBehaviour = (LesserBehaviour)applyTo.AddComponent(mType);
                thisBehaviour.data = this;

            }
            else
            {
                Debug.LogError("BehaviourScript string is not the name of a LesserBehaviour");
            }
        }
    }

    public override void UseItem(Item item)
    {
        MethodCrafting cache = CraftingPanels.Instance.method;

        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                for (int i = 0; i < cache.modSlots.Length; i++)
                {
                    if (cache.modSlots[i].myItem == null)
                    {
                        cache.modSlots[i].myItem = item;
                        cache.modSlots[i].myImage.sprite = inventoryIcon;
                        cache.modSlots[i].myImage.color = Color.white;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                        break;
                    }
                }

            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                for (int i = 0; i < CraftingPanels.Instance.core.modSlots.Length; i++)
                {
                    if (cache.modSlots[i].myItem == item)
                    {
                        cache.modSlots[i].myItem = null;
                        cache.modSlots[i].myImage.color = new Color(1, 1, 1, 0);
                        cache.modSlots[i].myImage.sprite = null;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                    }
                }

            }

        }
    }
}
