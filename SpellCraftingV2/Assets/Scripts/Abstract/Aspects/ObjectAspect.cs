using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAspect : Aspect
{
    //TODO: Make the aspect enter/exit the crafting/inventory

    [Header("Object Aspect")]
    [SerializeField] protected GameObject objectPrefab;


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
        applyTo.GetComponent<InnateEffect>().data = this;
        applyTo.GetComponent<InnateEffect>().caster = Caster;
    }
    protected abstract void OnDestruction();
    protected abstract void OnCreate();


    public override void UseItem()
    {
        Debug.Log("UseItem() not implemented in ObjectAspect");
    }
}