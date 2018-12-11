using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class should contain a behaivour that applies to a gameobject it's script is applied to. Should be used on core objects
/// </summary>
public abstract class Behaviour : MonoBehaviour {

    [HideInInspector] public ScriptableObject data;
    [SerializeField] protected BehaviourAspect.BehaviourType acceptBehaviourType = BehaviourAspect.BehaviourType.PROJECTILE;

    /// <summary>
    /// Include conditions for destroying the onbject
    /// </summary>
    protected abstract void DestructionHandler();

    /// <summary>
    /// Trust that only data similar to the returntype of AcceptModForType
    /// </summary>
    /// <param name="modData"></param>
    public abstract void ModMyVariables(ScriptableObject modData);


    /// <summary>
    /// Check if a mod can be applied to this object
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public virtual bool AcceptModOfType(BehaviourAspect.BehaviourType type)
    {
        //By default only accept mods with the same type as self
        if (type == acceptBehaviourType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
