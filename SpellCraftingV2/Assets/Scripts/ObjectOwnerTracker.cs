using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOwnerTracker : MonoBehaviour {

    private LivingEntity owner;

    public LivingEntity Owner
    {
        get
        {
            return owner;
        }
    }

    /// <summary>
    /// Call this function when all effects and behaviours are set-up on a object to set their owner, or when a spell is reflected to change it.
    /// </summary>
    /// <param name="newOwner"></param>
    public void UpdateOwner(LivingEntity newOwner)
    {
        owner = newOwner;

        InnateEffect[] _effects = this.gameObject.GetComponents<InnateEffect>();
        Behaviour _behaviour = this.gameObject.GetComponent<Behaviour>();
        LesserBehaviour[] _lesserBehaviours = this.gameObject.GetComponents<LesserBehaviour>();

        foreach (InnateEffect effect in _effects)
        {
            effect.caster = newOwner;
        }

        _behaviour.caster = newOwner;

        foreach (LesserBehaviour lesserBehaviour in _lesserBehaviours)
        {
            lesserBehaviour.caster = newOwner;
        }
    }
}
