using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourModAspect : Aspect
{

    //TODO: Verify that the order of GetComponents<>() returns the latest added Type at the end of the array

    [Header("Behaviour Mod Aspect")]
    [SerializeField] protected BehaviourAspect.BehaviourType modForType;
    [SerializeField] protected bool shouldApplyScript;
    [SerializeField] protected bool shouldChangeVariables;
    [SerializeField] protected string behaviourScript = "";


    [HideInInspector] public MethodRune Rune;

    #region GetSetters
    public bool ShouldApplyScript
    {
        get
        {
            return shouldApplyScript;
        }
    }
    public bool ShouldChangeVariables
    {
        get
        {
            return shouldChangeVariables;
        }
    }
    public BehaviourAspect.BehaviourType ModForType
    {
        get
        {
            return modForType;
        }
    }
    #endregion

    public virtual void SetModBehaviourAndData(GameObject applyTo)
    {
        //Check if the script exists, and is a Behaviour. If so, add it and if not debug errors
        System.Type mType = System.Type.GetType(behaviourScript);
        if (mType == null) //Does the string translate to the name of a class?
        {
            Debug.LogError("BehaviourScript string does not match any existing script name");
        }
        else
        {
            if (mType.GetType().IsInstanceOfType(typeof(LesserBehaviour))) //Is the class deriving from Behaviour?
            {
                //Add the class and set it's latest added LesserBehaviour data to a subclass of BehaviourModAspect
                LesserBehaviour thisBehaviour = (LesserBehaviour)applyTo.AddComponent(mType);
                thisBehaviour.data = this;

            }
            else
            {
                Debug.LogError("BehaviourScript string is not the name of a LesserBehaviour");
            }
        }
    }
}
