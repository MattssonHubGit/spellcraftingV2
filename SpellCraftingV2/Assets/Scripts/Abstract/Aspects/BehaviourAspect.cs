using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourAspect : Aspect
{

    //TODO: Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference

    public enum BehaviourType { PROJECTILE, ROTATING_AURA, RAIN, GROUND_SPIKE, RUNE }
    [Header("Behaviour Aspect")]
    [SerializeField] protected BehaviourType behaviourType;
    [SerializeField] protected string behaviourScript = "";

    

    /// <summary>
    /// A subclass should a component on a gameobject, meaning the behaivour should apply to it's own transform.
    /// </summary>
    public virtual void SetBehaviourAndData(GameObject applyTo)
    {
        //Check if the script exists, and is a Behaviour. If so, add it and if not debug errors
        System.Type mType = System.Type.GetType(behaviourScript);
        if (mType == null) //Does the string translate to the name of a class?
        {
            Debug.LogError("BehaviourScript string does not match any existing script name");
        }
        else
        {
            if (mType.GetType().IsInstanceOfType(typeof(Behaviour))) //Is the class deriving from Behaviour?
            {
                //Add the class and set it's data to a subclass of BehaviourAspect
                Behaviour thisBehaviour = (Behaviour)applyTo.AddComponent(mType);
                thisBehaviour.data = this;
            }
            else
            {
                Debug.LogError("BehaviourScript string is not the name of a Behaviour");
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
                if (cache.behaviourSlot.myItem == null)
                {
                    cache.behaviourSlot.myItem = item;
                    cache.behaviourSlot.myImage.sprite = inventoryIcon;
                    cache.behaviourSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cache.behaviourSlot.myItem == item)
                {
                    cache.behaviourSlot.myItem = null;
                    cache.behaviourSlot.myImage.color = new Color(1, 1, 1, 0);
                    cache.behaviourSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }
}
