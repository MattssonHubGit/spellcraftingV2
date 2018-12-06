﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAspect : Aspect
{
    //TODO: Make the aspect enter/exit the crafting/inventory

    [Header("Object Aspect")]
    [SerializeField] protected GameObject objectPrefab;
    [SerializeField] private string InnateEffectScript = "";


    [HideInInspector] public CoreRune Rune;

    #region GetSetters
    public GameObject ObjectPrefab
    {
        get
        {
            return objectPrefab;
        }
    }
    #endregion

    public virtual void SetInnateEffectData(GameObject applyTo)
    {
        //Check if the script exists, and is a InnateEffect. If so, add it and if not debug errors
        System.Type mType = System.Type.GetType(InnateEffectScript); 
        if(mType == null) //Does the string translate to the name of a class?
        {
            Debug.LogError("InnateEffectScript string does not match any existing script name");
        }
        else
        {
            if (mType.GetType().IsInstanceOfType(typeof(InnateEffect))) //Is the class deriving from InnateEffect?
            {
                //Add the class and set it's data to a subclass of ObjectAspect
                applyTo.AddComponent(mType);
                applyTo.GetComponent<InnateEffect>().data = this;
            }
            else
            {
                Debug.LogError("InnateEffectScript string is not the name of a InnateEffect");
            }
        }
    }
    protected abstract void OnDestruction();
    protected abstract void OnCreate();


    public override void UseItem()
    {
        Debug.Log("UseItem() not implemented in ObjectAspect");
    }
}