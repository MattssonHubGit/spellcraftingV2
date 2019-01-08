using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAspect : Aspect
{
    //TODO:  Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference

    [Header("Object Aspect")]
    [SerializeField] protected GameObject objectPrefab;
    [SerializeField] private string InnateEffectScript = "";
    [SerializeField] private ScriptableObject effectData;

    

    #region GetSetters
    public GameObject ObjectPrefab
    {
        get
        {
            return objectPrefab;
        }
    }
    #endregion

    /// <summary>
    /// A subclass should a component on a gameobject, meaning the behaivour should apply to it's own transform.
    /// </summary>
    public virtual void SetInnateEffectAndData(GameObject applyTo)
    {
        //Check if the script exists, and is a InnateEffect. If so, add it and if not debug errors
        System.Type mType = System.Type.GetType(InnateEffectScript); 
        if(mType == null) //Does the string translate to the name of a class?
        {
            Debug.LogError("InnateEffectScript string does not match any existing script name");
        }
        else
        {
            if (mType.GetType().IsInstanceOfType(typeof(InnateEffect))) //Is the class deriving from InnateEffect?
            {
                //Add the class and set it's data to a subclass of ObjectAspect
                InnateEffect thisEffect = (InnateEffect)applyTo.AddComponent(mType);
                thisEffect.data = effectData;
            }
            else
            {
                Debug.LogError("InnateEffectScript string is not the name of a InnateEffect");
            }
        }
    }

    public override void UseItem(Item item)
    {
        CoreCrafting cache = CraftingPanels.Instance.core;

        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cache.objectSlot.myItem == null)
                {
                    cache.objectSlot.myItem = item;
                    cache.objectSlot.myImage.sprite = inventoryIcon;
                    cache.objectSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cache.objectSlot.myItem == item)
                {
                    cache.objectSlot.myItem = null;
                    cache.objectSlot.myImage.color = new Color(1, 1, 1, 0);
                    cache.objectSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }
}