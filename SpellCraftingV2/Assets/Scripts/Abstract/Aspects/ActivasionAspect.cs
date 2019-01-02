using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivasionAspect : Aspect
{
    //TODO:  Replace FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory with a reference


    [HideInInspector] public RiteRune Rune;

    /// <summary>
    /// Check against the cost aspect if the caster succeeds with the payment, if it returns true - enter Cast, else enter Cancel.
    /// </summary>
    /// <param name="cost"></param>
    public abstract void Aim(CostAspect cost);

    /// <summary>
    /// A successfully paid cost is cast, creating a Core Object and applying all Mods and Behaivour Aspects to it
    /// </summary>
    protected abstract void Cast();

    /// <summary>
    /// A unsuccessful attempt to pay the cost results in a canceld aimed.
    /// </summary>
    protected abstract void Cancel();

    /// <summary>
    /// Greate the Core object and apply Methods to it, retuned object has .enabled == false.
    /// </summary>
    /// <param name="core"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    protected virtual GameObject GenerateCoreObject(/*CoreRune core, MethodRune method*/)
    {
        //Create object and supply with data
        GameObject coreObject = Instantiate(Rune.Page.Core.SpellObject.ObjectPrefab, new Vector3(-5000f, -5000f, -5000f), Quaternion.identity);
        Rune.Page.Core.SpellObject.SetInnateEffectAndData(coreObject);

        //Apply CoreMods
        for (int i = 0; i < Rune.Page.Core.Modifiers.Count; i++)
        {
            Rune.Page.Core.Modifiers[i].SetModEffectAndData(coreObject);
        }

        //Add behaviour
        Rune.Page.Method.Behaviour.SetBehaviourAndData(coreObject);

        //Mod behaviour
        for (int i = 0; i < Rune.Page.Method.Modifiers.Count; i++)
        {
            if (Rune.Page.Method.Modifiers[i].ShouldApplyScript) //Should the mod apply a new script to the object?
            {
                Rune.Page.Method.Modifiers[i].SetModBehaviourAndData(coreObject);
            }

            if (Rune.Page.Method.Modifiers[i].ShouldChangeVariables) //Should the mod change variables in the behaviour?
            {
                Behaviour _behaivourToMod = coreObject.GetComponent<Behaviour>();
                if (_behaivourToMod.AcceptModOfType(Rune.Page.Method.Modifiers[i].ModForType)) //Does the behaviour accept this mod?
                {
                    _behaivourToMod.ModMyVariables(Rune.Page.Method.Modifiers[i]);
                }
            }


        }

        //return it false to make it easier to reposition/set-up
        coreObject.SetActive(false);

        return coreObject;


        //return new GameObject("Created from helpfunction in ActivasionAspect");
    }

    public override void UseItem(Item item)
    {
        RiteCrafting cache = CraftingPanels.Instance.rite;

        //if in player inventory and crafting tile is open, place in crafting tile
        if (item.isInPlayerInventory == true)
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (cache.activationSlot.myItem == null)
                {
                    cache.activationSlot.myItem = item;
                    cache.activationSlot.myImage.sprite = inventoryIcon;
                    cache.activationSlot.myImage.color = Color.white;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.RemoveItem(item);
                }
            }
        }
        else
        {
            if (CraftingPanels.CraftingUIEnabled == true)
            {
                if (CraftingPanels.Instance.rite.activationSlot.myItem == item)
                {
                    cache.activationSlot.myItem = null;
                    cache.activationSlot.myImage.color = new Color(1, 1, 1, 0);
                    cache.activationSlot.myImage.sprite = null;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerInventory.AddItem(item, Camera.main.gameObject, false);
                }
            }

        }
    }
}
