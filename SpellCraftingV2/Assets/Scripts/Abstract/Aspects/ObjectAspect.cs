using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAspect : Aspect
{
    //TODO: Make the aspect enter/exit the crafting/inventory

    [Header("Object Aspect")]
    [SerializeField] protected GameObject objectPrefab;


    [HideInInspector] public CoreRune Rune;

    public virtual void SetInnateEffect(GameObject applyTo)
    {
        applyTo.GetComponent<InnateEffect>().data = this;
    }
    protected abstract void OnDestruction();
    protected abstract void OnCreate();


    public override void UseItem()
    {
        Debug.Log("UseItem() not implemented in ObjectAspect");
    }
}