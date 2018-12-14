using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreModAspect : Aspect
{
    //TODO: Verify that the order of GetComponents<>() returns the latest added Type at the end of the array

    [SerializeField] protected string effectScript = "";

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
            if (mType.GetType().IsInstanceOfType(typeof(LesserEffect))) //Is the class deriving from Behaviour?
            {
                //Add the class and set it's latest added LesserEffect data to a subclass of BehaviourModAspect
                LesserEffect thisEffect = (LesserEffect)applyTo.AddComponent(mType);
                thisEffect.data = this;

            }
            else
            {
                Debug.LogError("EffectScript string is not the name of a LesserEffect");
            }
        }
    }

}
