using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivasionAspect : Aspect
{
    //TODO: Apply methods to the gameobject returned by GenerateCoreObject
    //Make the aspect enter/exit the crafting/inventory
    //Apply CoreModAspects to the object in GenerateCoreObject
    //Apply MethodMods to the object in GenerateCoreObject


        [HideInInspector] public RiteRune Rune;

    /// <summary>
    /// Check against the cost aspect if the caster succeeds with the payment, if it returns true - enter Cast, else enter Cancel.
    /// </summary>
    /// <param name="cost"></param>
    public abstract void Aim(CostAspect cost);

    /// <summary>
    /// A successfully paid cost is cast, creating a Core Object and applying all Mods and Behaivour Aspects to it
    /// </summary>
    protected abstract void Cast(/*CoreRune core, MethodRune method*/);

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
        /*
         Add Coremods here 
        */

        Rune.Page.Method.Behaviour.SetBehaviourAndData(coreObject);
        /*
        Add Methods/Methodmods here
        */

        //return it false to make it easier to reposition/set-up
        coreObject.SetActive(false);

        return coreObject;


        //return new GameObject("Created from helpfunction in ActivasionAspect");
    }

    public override void UseItem()
    {
        Debug.Log("UseItem() not implemented in ActivasionAspect");
    }
}
