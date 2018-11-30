using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourAspect : Aspect
{
    public enum BehaviourType { PROJECTILE, ROTATING_AURA, RAIN, GROUND_SPIKE, RUNE }
    [Header("Behaviour Aspect")]
    [SerializeField] protected BehaviourType behaviourType;

    /// <summary>
    /// A subclass should a component on a gameobject, meaning the behaivour should apply to it's own transform.
    /// </summary>
    protected abstract void Behaivour();

    /// <summary>
    /// Any mod that changes a variable goes through here
    /// </summary>
    /// <param name="mod"></param>
    public abstract void TakeVariableModification(BehaviourModAspect mod);

    /// <summary>
    /// Check if a mod can be applied to this object
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public virtual bool AcceptModOfType(BehaviourType type)
    {
        //By default only accept mods with the same type as self
        if(type == this.behaviourType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
