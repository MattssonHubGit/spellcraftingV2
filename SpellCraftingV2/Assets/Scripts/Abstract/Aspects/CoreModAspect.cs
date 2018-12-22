using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreModAspect : Aspect
{
    //TODO: Make the aspect enter/exit the crafting/inventory and add additional mod slots

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

    public override void UseItem()
    {
        Debug.Log("UseItem() not implemented in CoreModAspect");
    }
}
