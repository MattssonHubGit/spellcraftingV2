using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivasionAspect : Aspect
{
    //TODO: Make GenerateCoreObject create the Core object and apply Methods to it - have it return with gameobject.enabled == false

    /// <summary>
    /// Check against the cost aspect if the caster succeeds with the payment, if it returns true - enter Cast, else enter Cancel.
    /// </summary>
    /// <param name="cost"></param>
    public abstract void Aim(CostAspect cost);

    /// <summary>
    /// A successfully paid cost is cast, creating a Core Object and applying all Mods and Behaivour Aspects to it
    /// </summary>
    protected abstract void Cast(CoreRune core, MethodRune method);

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
    protected virtual GameObject GenerateCoreObject(CoreRune core, MethodRune method)
    {
        return new GameObject("Created from helpfunction in ActivasionAspect");
    }
}
