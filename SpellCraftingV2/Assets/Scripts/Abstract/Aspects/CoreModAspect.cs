using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreModAspect : Aspect
{
    //TODO: Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference

    [SerializeField] protected string effectScript = "";
    [SerializeField] private ScriptableObject effectData;


    [HideInInspector] public CoreRune Rune;

    public virtual void SetModEffectAndData(GameObject applyTo)
    {
        //Check if the script exists, and is a Behaviour. If so, add it and if not debug errors
        System.Type mType = System.Type.GetType(effectScript);
        if (mType == null) //Does the string translate to the name of a class?
        {
            Debug.LogError("EffectScript string does not match any existing script name");
        }
        else
        {
            if (mType.GetType().IsInstanceOfType(typeof(InnateEffect))) //Is the class deriving from Behaviour?
            {
                //Add the class and set it's data to a subclass of BehaviourModAspect
                InnateEffect thisEffect = (InnateEffect)applyTo.AddComponent(mType);
                thisEffect.data = effectData;
                thisEffect.caster = Caster;

            }
            else
            {
                Debug.LogError("EffectScript string is not the name of a InnateEffect");
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
